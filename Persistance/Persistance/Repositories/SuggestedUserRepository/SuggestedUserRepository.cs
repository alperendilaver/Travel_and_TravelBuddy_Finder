using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.HobbyResults;
using Application.Features.Results.SuggestedUserResults;
using Application.Interfaces.SuggestedUserRep;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.SuggestedUserRepository
{
    public class SuggestedUserRepository : ISuggestedUserRepository
    {
        private readonly JourneyCloudContext _context;

        public SuggestedUserRepository(JourneyCloudContext context)
        {
            _context = context;
        }

        public async Task<List<SuggestedUsersResult>> GetSuggestedUsersAsync(string userId)
        {
            var entities = await _context.SuggestedUsers
                .Include(x => x.SuggestedUser)
                    .ThenInclude(x => x.TravelHistories)
                        .ThenInclude(x => x.TravelDestination)
                            .ThenInclude(x => x.Country)
                .Include(x => x.SuggestedUser)
                    .ThenInclude(x => x.TravelHistories)
                        .ThenInclude(x => x.TravelDestination)
                            .ThenInclude(x => x.City)
                .Include(x => x.SuggestedUser)
                    .ThenInclude(x => x.Hobbies)
                        .ThenInclude(x => x.Hobby)
                .Where(x => x.RequestingUserId == userId)
                .ToListAsync();
            return entities.Select(x => new SuggestedUsersResult
            {
                Age = x.SuggestedUser.Age,
                Bio = x.SuggestedUser.Bio,
                VisitedCountries = x.SuggestedUser.TravelHistories.Select(x => x.TravelDestination.Country.CountryName).Distinct().ToList(),
                VisitedCities = x.SuggestedUser.TravelHistories.Select(x => x.TravelDestination.City.CityName).ToList(),
                Hobbies = x.SuggestedUser.Hobbies.Select(x => new HobbyDTO { HobbyId = x.HobbyId, HobbyName = x.Hobby.HobbyName }).ToList(),
                UserId = x.SuggestedUserId,
                UserName = x.SuggestedUser.UserName,
                SuggestId = x.SuggestId,
            }).ToList();
        }
    }
}