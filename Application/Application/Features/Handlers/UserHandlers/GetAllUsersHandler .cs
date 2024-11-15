using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.UserQueries;
using Application.Features.Results.General;
using Application.Features.Results.UserResults;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Handlers.UserHandlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserResult>>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetAllUsersHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<UserResult>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {

            var users = await _userManager.Users.ToListAsync();
            return users.Select(user => new UserResult
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                GovernmentId = user.GovernmentId,
                Visa = user.Visa,
                Budget = user.Budget,
                Passport = user.Passpart,
                Gender = user.Gender
            }).ToList();



        }


    }
}