using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.SuggestedUserCommands
{
    public class RemoveSuggestedUserCommand : IRequest<GeneralResponse>
    {
        public int SuggestId { get; set; }

        public RemoveSuggestedUserCommand(int suggestId)
        {
            SuggestId = suggestId;
        }
    }
}