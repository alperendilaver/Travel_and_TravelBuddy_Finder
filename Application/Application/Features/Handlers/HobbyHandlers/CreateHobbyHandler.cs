using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.HobbyCommands;
using Application.Features.Results.General;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.HobbyHandlers
{
    public class CreateHobbyHandler : IRequestHandler<CreateHobbyCommand, GeneralResponse>
    {
        private readonly IRepository<Hobby> _repository;

        public CreateHobbyHandler(IRepository<Hobby> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(CreateHobbyCommand request, CancellationToken cancellationToken)
        {
            var Hobby = new Hobby
            {
                HobbyName = request.HobbyName,

            };
            try
            {

                await _repository.CreateAsync(Hobby);
                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = $"{Hobby.HobbyName} başarılı şekilde oluşturuldu"
                };
            }
            catch (System.Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }


    }

}