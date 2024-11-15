using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.UserHobbyCommands;
using Application.Features.Results.General;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.UserHobbyHandlers
{
    public class DeleteUserHobbyHandler : IRequestHandler<DeleteUserHobbyCommand, GeneralResponse>
    {
        private readonly IRepository<UserHobby> _repository;

        public DeleteUserHobbyHandler(IRepository<UserHobby> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(DeleteUserHobbyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserHobby = await _repository.GetByIdAsync(request.UserHobbyId);
                if (UserHobby == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Şehir bulunamadı" };
                }

                await _repository.RemoveAsync(UserHobby);

                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = "başarılı şekilde silindi"
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }
    }
}