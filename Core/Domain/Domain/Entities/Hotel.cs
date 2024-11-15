using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}