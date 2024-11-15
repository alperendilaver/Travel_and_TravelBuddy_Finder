using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.UserHobbyRep;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.UserHobbyRepository
{
    public class UserHobbyRepository : IUserHobbyRepository
    {
        private readonly JourneyCloudContext _journeyCloudContext;

        public UserHobbyRepository(JourneyCloudContext journeyCloudContext)
        {
            _journeyCloudContext = journeyCloudContext;
        }

        public async Task<List<UserHobby>> GetUserHobbiesAsync()
        {
            return await _journeyCloudContext.UserHobbies.Include(x => x.Hobby).Include(x => x.User).ToListAsync();
        }

        public async Task<UserHobby> GetUserHobbyAsync(int id)
        {
            return await _journeyCloudContext.UserHobbies.Include(x => x.Hobby).Include(x => x.User).FirstOrDefaultAsync(x => x.UserHobbyId == id);
        }
    }
}