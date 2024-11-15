using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Results.UserTravelHistoryResult
{
    public class UserTravelHistoryResult
    {
        public int LogId { get; set; }
        public string UserId { get; set; }
        public int TravelDestinationId { get; set; }
        public DateTime TravelDate { get; set; }
        public int Rating { get; set; }
    }
}