using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.FoodCommands
{
    public class UpdateFoodCommand : IRequest<GeneralResponse>
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }

    }
}