using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.HobbyQueries;
using Application.Features.Results.HobbyResults;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.HobbyHandlers
{
    public class GetCitiesByCountryHandler : IRequestHandler<GetAllHobbiesQuery, List<HobbyResult>>
    {
        private readonly IRepository<Hobby> _repository;

        public GetCitiesByCountryHandler(IRepository<Hobby> repository)
        {
            _repository = repository;
        }
        public async Task<List<HobbyResult>> Handle(GetAllHobbiesQuery request, CancellationToken cancellationToken)
        {
            var cities = await _repository.GetAllAsync();
            return cities
                .Select(c => new HobbyResult
                {
                    HobbyId = c.HobbyId,
                    HobbyName = c.HobbyName,
                })
                .ToList();
        }
    }
}