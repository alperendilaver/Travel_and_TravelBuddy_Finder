using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Results.NotifyResults
{
    public class NotificationResult
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public string ReceiverUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; } = false; // Bildirimin okunup okunmadığını belirtmek için   
    }
}