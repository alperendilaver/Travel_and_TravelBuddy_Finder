using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserTravelHistory
    {
        [Key]
        public int LogId { get; set; }
        public string UserId { get; set; }

        public AppUser User { get; set; }

        public int TravelDestinationId { get; set; }
        public TravelDestination TravelDestination { get; set; }
        public DateTime TravelDate { get; set; }
        public int Rating { get; set; } // Kullanıcının verdiği puan
    }
}