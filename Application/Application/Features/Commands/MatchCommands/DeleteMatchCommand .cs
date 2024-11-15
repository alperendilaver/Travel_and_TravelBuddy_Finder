using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.MatchCommands
{
    public class DeleteMatchCommand : IRequest<GeneralResponse>
    {

        public string LikerId { get; set; }
        public string LikeeId { get; set; }

        public DeleteMatchCommand(string likeeId, string likerId)
        {
            LikeeId = likeeId;
            LikerId = likerId;
        }
    }
}