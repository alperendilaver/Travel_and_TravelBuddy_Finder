using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.MatchQueries;
using Application.Features.Queries.SuggestedUserQueries;
using Application.Features.Results.MatchResults;
using Application.Features.Results.SuggestedUserResults;
using Application.Interfaces.MatchRep;
using MediatR;

namespace Application.Features.Handlers.MatchHandlers
{
    public class GetLikesForUserQueryHandler : IRequestHandler<GetLikesForUserQuery, List<MatchedUserDTO>>
    {
        private readonly IMatchRepository _matchRepository;

        public GetLikesForUserQueryHandler(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public async Task<List<MatchedUserDTO>> Handle(GetLikesForUserQuery request, CancellationToken cancellationToken)
        {
            return await _matchRepository.GetLikes(request.userId);
        }
    }
}