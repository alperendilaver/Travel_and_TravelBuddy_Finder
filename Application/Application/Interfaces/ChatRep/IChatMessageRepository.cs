using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Features.Results.General;
using Domain.Entities;

namespace Application.Interfaces.ChatRep
{
    public interface IChatMessageRepository
    {
        public Task AddMessageAsync(ChatMessage message);
        public Task<List<ChatMessage>> GetMessagesAsync(string senderUserId, string receiverUserId);

        public Task<int> ReadAMessage(int messageId);
        public Task<ChatMessage> GetMessage(int id);
        public Task<int> GetUnreadMessagesCount(string userId);

        public Task<List<ConversationDTO>> GetConversations(string userId);
        public Task<int> DeleteMessages(int[] messageids);
        public Task<int> DeleteConversation(string receiverUserId, string senderUserId);
    }
}