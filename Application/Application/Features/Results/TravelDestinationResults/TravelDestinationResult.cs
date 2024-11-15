using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Results.TravelDestinationResults
{
    public class TravelDestinationResult
    {
        public int TravelDestinationId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int PopularityValue { get; set; }
    }
}