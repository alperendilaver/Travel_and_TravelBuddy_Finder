using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.HotelResults;
using MediatR;

namespace Application.Features.Queries.HotelQueries
{
    public class GetHotelQuery : IRequest<HotelResult>
    {
        public int HotelId { get; set; }

        public GetHotelQuery(int hotelId)
        {
            HotelId = hotelId;
        }
    }
}