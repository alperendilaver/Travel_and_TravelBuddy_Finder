using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.CountryCommands;
using Application.Features.Results.General;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.CountryHandlers
{
    public class DeleteCountryHandler : IRequestHandler<DeleteCountryCommand, GeneralResponse>
    {
        private readonly IRepository<Country> _repository;

        public DeleteCountryHandler(IRepository<Country> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var country = await _repository.GetByIdAsync(request.CountryId);
                if (country == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Şehir bulunamadı" };
                }

                await _repository.RemoveAsync(country);

                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = $"{country.CountryName} başarılı şekilde silindi"
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }
    }
}