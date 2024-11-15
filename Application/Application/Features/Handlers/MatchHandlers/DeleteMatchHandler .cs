using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.MatchCommands;
using Application.Features.Results.General;
using Application.Interfaces.IGeneralRepository;
using Application.Interfaces.MatchRep;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.MatchHandlers
{
    public class DeleteMatchHandler : IRequestHandler<DeleteMatchCommand, GeneralResponse>
    {
        private readonly IMatchRepository _repository;

        public DeleteMatchHandler(IMatchRepository repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(DeleteMatchCommand request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse();
            try
            {
                response.IsSucceded = await _repository.DeleteMatch(request.LikerId, request.LikeeId) > 0 ? true : false;
                response.Message = response.IsSucceded ? "Başarılı şekilde silindi" : "Silinemedi";
            }
            catch (Exception ex)
            {
                response.IsSucceded = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}