using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.HotelCommands
{
    public class DeleteHotelCommand : IRequest<GeneralResponse>
    {
        public int HotelId { get; set; }

        public DeleteHotelCommand(int hotelId)
        {
            HotelId = hotelId;
        }
    }
}