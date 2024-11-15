using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.MessageCommands;
using Application.Features.Queries.MessageQueries;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMediator _mediator;

        public ChatHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task DeleteMessages(int[] messageIds, string senderUserId, string receiverUserId)
        {
            // Mesajları veritabanından sil
            var command = new DeleteMessagesCommand(messageIds);
            var result = await _mediator.Send(command);

            if (result)
            {
                // Alıcıya mesajların silindiğini bildirme
                await Clients.User(receiverUserId).SendAsync("MessagesDeleted", messageIds);
                await Clients.User(senderUserId).SendAsync("MessagesDeleted", messageIds); // Göndericiye de güncel durumu gönder
            }
        }
        public async Task SendMessage(string senderUserId, string receiverUserId, string encryptedMessageForReceiver, string encryptedMessageForSender)
        {
            // Mesajı veritabanına kaydet ve oluşturulan mesaj ID'sini al
            var command = new SendMessageCommand(senderUserId, receiverUserId, encryptedMessageForReceiver, encryptedMessageForSender);
            var messageId = await _mediator.Send(command);

            // Mesajı alıcıya gönder
            await Clients.User(receiverUserId).SendAsync("ReceiveMessage", senderUserId, encryptedMessageForReceiver, messageId);
            // Ayrıca gönderen kullanıcıya da mesaj ID'sini gönder
            await Clients.User(senderUserId).SendAsync("MessageSent", messageId, encryptedMessageForSender);
        }

        public async Task MarkMessageAsRead(int messageId, string receiverUserId)
        {
            try
            {
                var command = new MessageReadCommand(messageId, receiverUserId);
                await _mediator.Send(command);
                var message = await _mediator.Send(new GetMessageByIdQuery(messageId));

                if (message != null)
                {
                    // Notify sender that the message has been read
                    await Clients.User(message.SenderUserId).SendAsync("MessageRead", messageId);
                }
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error in MarkMessageAsRead: {ex.Message}");
            }
        }

        public override Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            if (!string.IsNullOrEmpty(userId))
            {
                Groups.AddToGroupAsync(Context.ConnectionId, userId);
            }
            return base.OnConnectedAsync();
        }
    }
}
