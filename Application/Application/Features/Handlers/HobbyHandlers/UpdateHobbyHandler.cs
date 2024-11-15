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
    public class UpdateHobbyHandler : IRequestHandler<UpdateHobbyCommand, GeneralResponse>
    {
        private readonly IRepository<Hobby> _repository;

        public UpdateHobbyHandler(IRepository<Hobby> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(UpdateHobbyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var hobby = await _repository.GetByIdAsync(request.HobbyId);
                if (hobby == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Şehir bulunamadı" };
                }

                hobby.HobbyName = request.HobbyName;

                await _repository.UpdateAsync(hobby);

                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = $"{hobby.HobbyName} başarılı şekilde güncellendi"
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }
    }

}