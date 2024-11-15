using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.FoodCommands
{
    public class DeleteFoodCommand : IRequest<GeneralResponse>
    {
        public DeleteFoodCommand(int id)
        {
            FoodId = id;
        }

        public int FoodId { get; set; }
    }
}