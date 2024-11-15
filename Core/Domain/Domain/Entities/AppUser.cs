using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string GovernmentId { get; set; }
        public bool Visa { get; set; }
        public int Budget { get; set; }
        public bool Passpart { get; set; }
        //public string Image { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public string Bio { get; set; }
        public List<Match> Matches { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<UserHobby> Hobbies { get; set; } // Kullanıcı hobileri ile ilişki
        public List<UserTravelHistory> TravelHistories { get; set; } // Kullanıcı seyahat geçmişi
        public List<ChatMessage> SentMessages { get; set; } // Gönderilen mesajlar
        public List<ChatMessage> ReceivedMessages { get; set; } // Alınan mesajlar
        public List<SuggestedUsers> SuggestedUsers { get; set; }
    }
}