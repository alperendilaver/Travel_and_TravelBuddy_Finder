using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.UserTravelHistoryCommands
{
    public class UpdateUserTravelHistoryCommand : IRequest<GeneralResponse>
    {
        public int LogId { get; set; }
        public DateTime TravelDate { get; set; }
        public int Rating { get; set; }

    }
}