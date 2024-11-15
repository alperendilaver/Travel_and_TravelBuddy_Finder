using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Results.CountryResults
{
    public class CountryResult
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public List<string> CityName { get; set; }
    }
}