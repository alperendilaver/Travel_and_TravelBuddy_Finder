using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Results.MatchResults
{
    public class MatchResult
    {
        public int MatchId { get; set; }
        public string FirstUserId { get; set; }
        public string FirstUserName { get; set; }
        public string SecondUserName { get; set; }
        public string SecondUserId { get; set; }
        public int TravelDestinationId { get; set; }
    }
}