using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TravelSuggestion
    {
        [Key]
        public int SuggestionId { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }

        public int RouteId { get; set; }
        public TravelRoute Route { get; set; }
    }

}