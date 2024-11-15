using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.CountryCommands
{
    public class CreateCountryCommand : IRequest<GeneralResponse>
    {
        public string CountryName { get; set; }

    }
}