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
    public class UpdateUserHobbyHandler : IRequestHandler<UpdateUserHobbyCommand, GeneralResponse>
    {
        private readonly IRepository<UserHobby> _repository;

        public UpdateUserHobbyHandler(IRepository<UserHobby> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(UpdateUserHobbyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userHobby = await _repository.GetByIdAsync(request.UserHobbyId);
                if (userHobby == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Şehir bulunamadı" };
                }

                userHobby.HobbyId = request.HobbyId;
                await _repository.UpdateAsync(userHobby);

                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = "başarılı şekilde güncellendi"
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }
    }

}