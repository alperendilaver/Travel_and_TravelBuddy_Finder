using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Application.Features.Results.HobbyResults;
using Application.Features.Results.MatchResults;
using Application.Features.Results.SuggestedUserResults;
using Application.Features.Results.UserResults;
using Application.Interfaces.MatchRep;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.MatchRepository
{
    public class MatchRepository : IMatchRepository
    {
        private readonly JourneyCloudContext _journeyCloudContext;

        public MatchRepository(JourneyCloudContext journeyCloudContext)
        {
            _journeyCloudContext = journeyCloudContext;
        }

        public async Task<int> AddMatch(Domain.Entities.Match match)
        {
            await _journeyCloudContext.AddAsync(match);
            var result = await _journeyCloudContext.SaveChangesAsync();
            if (result > 0)
            {
                var likeeuser = await _journeyCloudContext.SuggestedUsers.FirstOrDefaultAsync(x => x.SuggestedUserId == match.LikeeId && x.RequestingUserId == match.LikerId);
                _journeyCloudContext.SuggestedUsers.Remove(likeeuser);

            }
            return await _journeyCloudContext.SaveChangesAsync();
        }

        public async Task<Domain.Entities.Match> CheckMatch(string LikerId, string LikeeId)
        {
            return await _journeyCloudContext.Matches.FirstOrDefaultAsync(x => x.LikerId == LikerId && x.LikeeId == LikeeId);
        }

        public async Task<Domain.Entities.Match> CheckReciprocalMatch(string LikerId, string LikeeId)
        {
            return await _journeyCloudContext.Matches.FirstOrDefaultAsync(x => x.LikerId == LikeeId && x.LikeeId == LikerId && x.IsLiked);
        }

        public async Task<int> DeleteMatch(string LikerId, string LikeeId)
        {
            var matches = await _journeyCloudContext.Matches.Where(x => x.LikeeId == LikeeId && x.LikerId == LikerId || x.LikerId == LikeeId && x.LikeeId == LikerId).ToListAsync();
            _journeyCloudContext.RemoveRange(matches);
            return await _journeyCloudContext.SaveChangesAsync();
        }

        public async Task<List<Domain.Entities.Match>> GetAllMatchesAsync()
        {
            return await _journeyCloudContext.Matches.Include(x => x.Liker).Include(x => x.Likee).Include(x => x.Destination).ToListAsync();
        }

        public async Task<List<MatchedUserDTO>> GetLikes(string LikerId)
        {
            var entities = await _journeyCloudContext.Matches
                .Where(x => x.LikerId == LikerId && x.IsLiked == true)
                .Include(x => x.Likee)
                    .ThenInclude(x => x.TravelHistories)
                        .ThenInclude(x => x.TravelDestination)
                            .ThenInclude(x => x.Country)
                .Include(x => x.Likee)
                    .ThenInclude(x => x.TravelHistories)
                        .ThenInclude(x => x.TravelDestination)
                            .ThenInclude(x => x.City)
                .Include(x => x.Likee)
                    .ThenInclude(x => x.Hobbies)
                        .ThenInclude(x => x.Hobby)
                .ToListAsync();
            return entities.Select(x => new MatchedUserDTO
            {
                Age = x.Likee.Age,
                Bio = x.Likee.Bio,
                VisitedCountries = x.Likee.TravelHistories.Select(x => x.TravelDestination.Country.CountryName).Distinct().ToList(),
                VisitedCities = x.Likee.TravelHistories.Select(x => x.TravelDestination.City.CityName).ToList(),
                Hobbies = x.Likee.Hobbies.Select(x => new HobbyDTO { HobbyId = x.HobbyId, HobbyName = x.Hobby.HobbyName }).ToList(),
                UserId = x.LikeeId,
                UserName = x.Likee.UserName,
                IsMatched = x.IsMatched,
                MatchId = x.MatchId
            }).ToList();
        }

        public async Task<Domain.Entities.Match> GetMatchAsync(int matchId)
        {
            return await _journeyCloudContext.Matches.Include(x => x.Liker).Include(x => x.Likee).Include(x => x.Destination).FirstOrDefaultAsync(x => x.MatchId == matchId);
        }

        public async Task<List<UserMatchDTO>> GetUserMatches(string userId)
        {
            return await _journeyCloudContext.Matches
                .Where(m => (m.LikerId == userId) && m.IsMatched)
                .Select(m => new UserMatchDTO { Id = m.Likee.Id, UserName = m.Likee.UserName, Email = m.Likee.Email, Phone = m.Likee.PhoneNumber, Bio = "" })
                .ToListAsync();

        }

        public async Task<int> UpdateMatches(Domain.Entities.Match existMatch, Domain.Entities.Match reciprocalMatch)
        {
            existMatch.IsMatched = true;
            reciprocalMatch.IsMatched = true;
            _journeyCloudContext.UpdateRange(existMatch, reciprocalMatch);
            return await _journeyCloudContext.SaveChangesAsync();
        }
    }
}