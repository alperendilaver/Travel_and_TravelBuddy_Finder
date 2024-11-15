using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.CityCommands
{
    public class UpdateCityCommand : IRequest<GeneralResponse>
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

    }
}