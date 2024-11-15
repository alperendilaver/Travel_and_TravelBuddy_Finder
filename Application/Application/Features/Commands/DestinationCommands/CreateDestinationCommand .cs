using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.DestinationCommands
{
    public class CreateDestinationCommand : IRequest<GeneralResponse>
    {
        public string DestinationName { get; set; }
        public int CityId { get; set; }
    }
}