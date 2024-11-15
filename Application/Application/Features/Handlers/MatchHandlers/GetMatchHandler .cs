using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.MatchQueries;
using Application.Features.Results.MatchResults;
using Application.Interfaces.IGeneralRepository;
using Application.Interfaces.MatchRep;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.MatchHandlers
{
    public class GetMatchHandler : IRequestHandler<GetMatchQuery, MatchResult>
    {
        private readonly IMatchRepository _repository;

        public GetMatchHandler(IMatchRepository repository)
        {
            _repository = repository;
        }

        public async Task<MatchResult> Handle(GetMatchQuery request, CancellationToken cancellationToken)
        {
            var match = await _repository.GetMatchAsync(request.MatchId);

            return new MatchResult
            {
                MatchId = match.MatchId,
                FirstUserId = match.LikerId,
                FirstUserName = match.Liker.UserName,
                SecondUserId = match.LikeeId,
                SecondUserName = match.Likee.UserName,
                TravelDestinationId = match.TravelDestinaitonId
            };

        }
    }
}
