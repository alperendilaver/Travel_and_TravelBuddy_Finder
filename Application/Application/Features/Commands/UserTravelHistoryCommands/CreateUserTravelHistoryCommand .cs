using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using Application.Features.Results.UserTravelHistoryResult;
using MediatR;

namespace Application.Features.Commands.UserTravelHistoryCommands
{
    public class CreateUserTravelHistoryCommand : IRequest<UserTravelHistoryResult>
    {
        public string UserId { get; set; }
        public int TravelDestinationId { get; set; }
        public DateTime TravelDate { get; set; }
        public int Rating { get; set; }
    }
}