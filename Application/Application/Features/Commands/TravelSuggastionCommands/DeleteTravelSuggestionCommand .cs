using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.TravelSuggastionCommands
{
    public class DeleteTravelSuggestionCommand : IRequest<GeneralResponse>
    {
        public DeleteTravelSuggestionCommand(int suggestionId)
        {
            this.SuggestionId = suggestionId;

        }
        public int SuggestionId { get; set; }
    }
}