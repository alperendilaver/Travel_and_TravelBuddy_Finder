using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.HotelResults;
using MediatR;

namespace Application.Features.Queries.HotelQueries
{
    public class GetHotelsByCityQuery : IRequest<List<HotelResult>>
    {
        public int CityId { get; set; }
    }
}