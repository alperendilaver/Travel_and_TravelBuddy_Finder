using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.FoodCommands
{
    public class CreateFoodCommand : IRequest<GeneralResponse>
    {
        public string FoodName { get; set; }

    }
}