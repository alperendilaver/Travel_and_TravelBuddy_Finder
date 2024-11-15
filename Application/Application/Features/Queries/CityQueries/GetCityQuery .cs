using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.CityResults;
using MediatR;

namespace Application.Features.Queries.CityQueries
{
    public class GetCityQuery : IRequest<CityResult>
    {
        public int CityId { get; set; }

        public GetCityQuery(int cityId)
        {
            CityId = cityId;
        }
    }
}