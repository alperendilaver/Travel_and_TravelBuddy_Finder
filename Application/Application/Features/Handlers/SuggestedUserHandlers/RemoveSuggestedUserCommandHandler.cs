using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.SuggestedUserCommands;
using Application.Features.Results.General;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.SuggestedUserHandlers
{
    public class RemoveSuggestedUserCommandHandler : IRequestHandler<RemoveSuggestedUserCommand, GeneralResponse>
    {
        private IRepository<SuggestedUsers> _repository;

        public RemoveSuggestedUserCommandHandler(IRepository<SuggestedUsers> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(RemoveSuggestedUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.SuggestId);
            var response = new GeneralResponse();
            try
            {
                await _repository.RemoveAsync(entity);
                response.Message = "Başarı ile silindi";
                response.IsSucceded = false;
            }
            catch (System.Exception ex)
            {
                response.IsSucceded = false;
                response.Message = ex.Message;
            }
            return response;
        }

    }
}