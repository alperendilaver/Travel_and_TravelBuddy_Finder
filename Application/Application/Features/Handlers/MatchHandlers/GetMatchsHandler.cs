using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.MatchQueries;
using Application.Features.Results.MatchResults;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.MatchHandlers
{
    public class GetMatchsHandler : IRequestHandler<GetMatchesByUserQuery, List<MatchResult>>
    {
        private readonly IRepository<Match> _repository;

        public GetMatchsHandler(IRepository<Match> repository)
        {
            _repository = repository;
        }
        public async Task<List<MatchResult>> Handle(GetMatchesByUserQuery request, CancellationToken cancellationToken)
        {
            var Matchs = await _repository.GetAllAsync();
            return Matchs
                .Select(c => new MatchResult
                {
                    MatchId = c.MatchId,
                    FirstUserId = c.LikerId,
                    FirstUserName = c.Liker.UserName,
                    SecondUserId = c.LikeeId,
                    SecondUserName = c.Likee.UserName,
                    TravelDestinationId = c.TravelDestinaitonId
                })
                .ToList();
        }
    }
}