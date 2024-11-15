using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.UserHobbyRep
{
    public interface IUserHobbyRepository
    {
        public Task<UserHobby> GetUserHobbyAsync(int id);
        public Task<List<UserHobby>> GetUserHobbiesAsync();
    }
}