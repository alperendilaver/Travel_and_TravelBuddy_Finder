using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Results.UserHobbyResults
{
    public class UserHobbyResult
    {
        public int UserHobbyId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string HobbyName { get; set; }
        public int HobbyId { get; set; }
    }
}