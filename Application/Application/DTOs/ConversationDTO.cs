using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ConversationDTO
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string LastMessage { get; set; }
        public string LastMessageTime { get; set; }
        public int UnreadCount { get; set; }
    }
}