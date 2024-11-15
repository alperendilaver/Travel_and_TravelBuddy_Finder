using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.CountryCommands
{
    public class UpdateCountryCommand : IRequest<GeneralResponse>
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}