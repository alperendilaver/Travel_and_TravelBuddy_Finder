using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TravelRoute
    {
        [Key]
        public int RouteId { get; set; }
        public int SuggestionId { get; set; }
        public TravelSuggestion Suggestion { get; set; }
        public List<TravelDestination> Destinations { get; set; }
        public List<Hotel> Hotels { get; set; }
        public List<Food> Foods { get; set; }

    }
}