using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.MatchResults;
using Application.Features.Results.SuggestedUserResults;
using Application.Features.Results.UserResults;
using Domain.Entities;

namespace Application.Interfaces.MatchRep
{
    public interface IMatchRepository
    {
        public Task<Domain.Entities.Match> GetMatchAsync(int matchId);
        public Task<List<Domain.Entities.Match>> GetAllMatchesAsync();

        public Task<Domain.Entities.Match> CheckMatch(string LikerId, string LikeeId);
        public Task<int> AddMatch(Match match);
        public Task<Match> CheckReciprocalMatch(string LikerId, string LikeeId);
        public Task<int> UpdateMatches(Match existMatch, Match reciprocalMatch);
        public Task<List<UserMatchDTO>> GetUserMatches(string userId);
        public Task<int> DeleteMatch(string LikerId, string LikeeId);
        public Task<List<MatchedUserDTO>> GetLikes(string LikerId);
    }
}