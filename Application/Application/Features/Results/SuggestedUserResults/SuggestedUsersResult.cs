using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.HobbyResults;
using Domain.Entities;

namespace Application.Features.Results.SuggestedUserResults
{
    public class SuggestedUsersResult
    {
        public int SuggestId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Image => "";
        public int Age { get; set; }
        public string Bio { get; set; }
        public List<HobbyDTO> Hobbies { get; set; }
        public List<string> VisitedCountries { get; set; }
        public List<string> VisitedCities { get; set; }
    }

}