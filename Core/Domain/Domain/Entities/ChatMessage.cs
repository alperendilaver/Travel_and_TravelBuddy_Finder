using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string SenderUserId { get; set; }
        [ForeignKey("SenderUserId")]
        public AppUser SenderUser { get; set; }

        public string ReceiverUserId { get; set; }
        [ForeignKey("ReceiverUserId")]
        public AppUser ReceiverUser { get; set; }
  
        public string EncryptedMessageForReceiver { get; set; }
        public string EncryptedMessageForSender { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; } = false;
    }
}