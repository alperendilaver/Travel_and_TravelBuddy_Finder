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
    public class GetHobbyHandler : IRequestHandler<GetHobbyQuery, HobbyResult>
    {
        private readonly IRepository<Hobby> _repository;

        public GetHobbyHandler(IRepository<Hobby> repository)
        {
            _repository = repository;
        }

        public async Task<HobbyResult> Handle(GetHobbyQuery request, CancellationToken cancellationToken)
        {
            var hobby = await _repository.GetByIdAsync(request.HobbyId);

            return new HobbyResult
            {
                HobbyId = hobby.HobbyId,
                HobbyName = hobby.HobbyName,

            };

        }
    }
}
