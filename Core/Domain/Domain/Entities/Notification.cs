using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public string ReceiverUserId { get; set; }
        [ForeignKey("ReceiverUserId")]
        public AppUser Receiver { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; } = false; // Bildirimin okunup okunmadığını belirtmek için
    }
}