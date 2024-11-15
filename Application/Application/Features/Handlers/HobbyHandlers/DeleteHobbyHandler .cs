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
    public class DeleteHobbyHandler : IRequestHandler<DeleteHobbyCommand, GeneralResponse>
    {
        private readonly IRepository<Hobby> _repository;

        public DeleteHobbyHandler(IRepository<Hobby> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(DeleteHobbyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Hobby = await _repository.GetByIdAsync(request.HobbyId);
                if (Hobby == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Şehir bulunamadı" };
                }

                await _repository.RemoveAsync(Hobby);

                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = $"{Hobby.HobbyName} başarılı şekilde silindi"
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }
    }
}