using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Features.Results.General;
using Application.Interfaces.ChatRep;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.MessageRepository
{
    public class ChatMessageRepository : IChatMessageRepository
    {
        private readonly JourneyCloudContext _context;

        public ChatMessageRepository(JourneyCloudContext journeyCloudContext)
        {
            _context = journeyCloudContext;
        }

        public async Task AddMessageAsync(ChatMessage message)
        {
            _context.ChatMessages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteConversation(string firstUserId, string secondUserId)
        {
            var conversation = await _context.ChatMessages.Where(x => (x.SenderUserId == firstUserId && x.ReceiverUserId == secondUserId) || (x.SenderUserId == secondUserId && x.ReceiverUserId == firstUserId)).ToListAsync();
            _context.ChatMessages.RemoveRange(conversation);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteMessages(int[] messageids)
        {
            var messages = await _context.ChatMessages.Where(x => messageids.Contains(x.Id)).ToListAsync();
            _context.ChatMessages.RemoveRange(messages);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<ConversationDTO>> GetConversations(string userId)
        {
            var conversations = await _context.ChatMessages
                .Where(x => x.ReceiverUserId == userId || x.SenderUserId == userId)
                .GroupBy(x => x.SenderUserId == userId ? x.ReceiverUserId : x.SenderUserId) // Diğer kullanıcıya göre grupla
                .Select(g => new ConversationDTO
                {
                    UserId = g.Key, // Diğer kullanıcının kimliği
                    FullName = g.Select(m => m.SenderUserId == userId ? m.ReceiverUser.UserName : m.SenderUser.UserName).FirstOrDefault(),
                    LastMessage = g.OrderByDescending(m => m.Timestamp).Select(m => m.EncryptedMessageForReceiver).FirstOrDefault(),
                    LastMessageTime = g.OrderByDescending(m => m.Timestamp).Select(m => m.Timestamp.ToString("g")).FirstOrDefault(),
                    UnreadCount = g.Count(m => m.ReceiverUserId == userId && !m.IsRead)
                })
                .ToListAsync();

            return conversations;
        }


        public async Task<ChatMessage> GetMessage(int id)
        {
            return await _context.ChatMessages.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ChatMessage>> GetMessagesAsync(string senderUserId, string receiverUserId)
        {
            return await _context.ChatMessages
            .Where(m => (m.SenderUserId == senderUserId && m.ReceiverUserId == receiverUserId) ||
                        (m.SenderUserId == receiverUserId && m.ReceiverUserId == senderUserId))
            .OrderBy(m => m.Timestamp)
            .ToListAsync();
        }

        public async Task<int> GetUnreadMessagesCount(string userId)
        {
            return await _context.ChatMessages.Where(x => x.ReceiverUserId == userId && x.IsRead == false).CountAsync();
        }

        public async Task<int> ReadAMessage(int messageId)
        {
            var message = await _context.ChatMessages.FindAsync(messageId);
            if (message == null)
            {
                return 0;
            }
            message.IsRead = true;
            return await _context.SaveChangesAsync();
        }
    }
}