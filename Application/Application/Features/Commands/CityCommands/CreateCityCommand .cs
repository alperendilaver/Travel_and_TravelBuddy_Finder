using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.CityCommands
{
    public class CreateCityCommand : IRequest<GeneralResponse>
    {
        public string CityName { get; set; }
        public int CountryId { get; set; }

    }
}