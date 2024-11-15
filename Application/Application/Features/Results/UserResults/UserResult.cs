using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.UserHobbyResults;

namespace Application.Features.Results.UserResults
{
    public class UserResult
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string GovernmentId { get; set; }
        public bool Visa { get; set; }
        public int Budget { get; set; }
        public bool Passport { get; set; }
        public bool Gender { get; set; }
        public List<UserHobbyResult> Hobbies { get; set; }
        //  public List<UserTravelHistoryResult> TravelHistories { get; set; }
    }
}