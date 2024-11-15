using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.UserResults;
using Application.Interfaces.UserRepository;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly JourneyCloudContext _context;

        public UserRepository(JourneyCloudContext journeyCloudContext)
        {
            _context = journeyCloudContext;
        }

        public async Task<GetRoleNameQueryResult> GetRole(string userId)
        {
            var userRole = await _context.UserRoles.FirstOrDefaultAsync(x => x.UserId == userId);
            var roleId = userRole?.RoleId ?? "0";
            var rolename = await _context.Roles.FirstOrDefaultAsync(x => x.Id == roleId);
            return new GetRoleNameQueryResult { RoleName = rolename?.Name };
        }
    }
}