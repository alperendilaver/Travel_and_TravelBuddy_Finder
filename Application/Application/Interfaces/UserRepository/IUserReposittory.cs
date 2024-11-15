using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.UserResults;

namespace Application.Interfaces.UserRepository
{
    public interface IUserRepository
    {
        public Task<GetRoleNameQueryResult> GetRole(string userId);

    }
}