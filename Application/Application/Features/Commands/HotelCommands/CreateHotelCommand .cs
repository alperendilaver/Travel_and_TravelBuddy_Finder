using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.HotelCommands
{
    public class CreateHotelCommand : IRequest<GeneralResponse>
    {
        public string HotelName { get; set; }
        public int CityId { get; set; }
        public int Rating { get; set; }
    }
}