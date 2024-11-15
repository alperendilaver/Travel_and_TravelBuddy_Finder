using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.CityCommands
{
    public class DeleteCityCommand : IRequest<GeneralResponse>
    {
        public int CityId { get; set; }

        public DeleteCityCommand(int cityId)
        {
            CityId = cityId;
        }
    }
}