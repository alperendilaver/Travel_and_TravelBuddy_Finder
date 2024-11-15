using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.MatchQueries;
using Application.Features.Results.UserResults;
using Application.Interfaces.MatchRep;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.MatchHandlers
{
    public class GetMatchesForUserQueryHandler : IRequestHandler<GetMatchesForUserQuery, List<UserMatchDTO>>
    {
        private readonly IMatchRepository _matchRepository;

        public GetMatchesForUserQueryHandler(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public async Task<List<UserMatchDTO>> Handle(GetMatchesForUserQuery request, CancellationToken cancellationToken)
        {
            return await _matchRepository.GetUserMatches(request.UserId);
        }
    }
}