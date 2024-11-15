using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Results.HotelResults
{
    public class HotelResult
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int Rating { get; set; }
    }
}