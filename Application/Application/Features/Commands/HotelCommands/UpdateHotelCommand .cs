using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.HotelCommands
{
    public class UpdateHotelCommand : IRequest<GeneralResponse>
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public int Rating { get; set; }

    }
}