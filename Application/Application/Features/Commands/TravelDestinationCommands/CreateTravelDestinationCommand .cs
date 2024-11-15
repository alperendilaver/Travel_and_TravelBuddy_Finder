using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.TravelDestinationCommands
{
    public class CreateTravelDestinationCommand : IRequest<GeneralResponse>
    {
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int PopularityValue { get; set; }

    }
}