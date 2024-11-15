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
    public class CreateUserHobbyHandler : IRequestHandler<CreateUserHobbyCommand, GeneralResponse>
    {
        private readonly IRepository<UserHobby> _repository;

        public CreateUserHobbyHandler(IRepository<UserHobby> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(CreateUserHobbyCommand request, CancellationToken cancellationToken)
        {
            var UserHobby = new UserHobby
            {
                UserId = request.UserId,
                HobbyId = request.HobbyId,
            };
            try
            {

                await _repository.CreateAsync(UserHobby);
                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = "başarılı şekilde oluşturuldu"
                };
            }
            catch (System.Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }


    }

}