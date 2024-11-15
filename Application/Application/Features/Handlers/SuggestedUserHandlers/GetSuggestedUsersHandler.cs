using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.SuggestedUserQueries;
using Application.Features.Results.SuggestedUserResults;
using Application.Interfaces.SuggestedUserRep;
using MediatR;

namespace Application.Features.Handlers.SuggestedUserHandlers
{
    public class GetSuggestedUsersHandler : IRequestHandler<GetSuggestedUsersQuery, List<SuggestedUsersResult>>
    {
        private readonly ISuggestedUserRepository _repository;

        public GetSuggestedUsersHandler(ISuggestedUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SuggestedUsersResult>> Handle(GetSuggestedUsersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetSuggestedUsersAsync(request.UserId);
        }
    }
}