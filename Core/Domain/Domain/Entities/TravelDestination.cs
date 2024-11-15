using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TravelDestination
    {
        [Key]
        public int TravelDestinationId { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int PopularityValue { get; set; }
        [JsonIgnore]
        public List<UserTravelHistory> UserTravelHistories { get; set; } // Kullanıcı seyahat geçmişi ile ilişki
    }
}