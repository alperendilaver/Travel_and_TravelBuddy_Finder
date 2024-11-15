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
    public class UpdateCountryHandler : IRequestHandler<UpdateCountryCommand, GeneralResponse>
    {
        private readonly IRepository<Country> _repository;

        public UpdateCountryHandler(IRepository<Country> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var country = await _repository.GetByIdAsync(request.CountryId);
                if (country == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Şehir bulunamadı" };
                }

                country.CountryName = request.CountryName;

                await _repository.UpdateAsync(country);

                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = $"{country.CountryName} başarılı şekilde güncellendi"
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }
    }

}