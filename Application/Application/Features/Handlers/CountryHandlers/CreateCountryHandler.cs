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
    public class CreateCountryHandler : IRequestHandler<CreateCountryCommand, GeneralResponse>
    {
        private readonly IRepository<Country> _repository;

        public CreateCountryHandler(IRepository<Country> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var country = new Country
            {
                CountryName = request.CountryName,

            };
            try
            {

                await _repository.CreateAsync(country);
                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = $"{country.CountryName} başarılı şekilde oluşturuldu"
                };
            }
            catch (System.Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }


    }

}