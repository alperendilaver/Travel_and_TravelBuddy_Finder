using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.UserQueries;
using Application.Features.Results.General;
using Application.Features.Results.UserHobbyResults;
using Application.Features.Results.UserResults;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Handlers.UserHandlers
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, GeneralResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetUserHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<GeneralResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Kullanıcı bulunamadı" };
                }

                var result = new UserResult
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    GovernmentId = user.GovernmentId,
                    Visa = user.Visa,
                    Budget = user.Budget,
                    Passport = user.Passpart,
                    Gender = user.Gender,
                    Hobbies = user.Hobbies?.Select(h => new UserHobbyResult
                    {
                        UserHobbyId = h.UserHobbyId,
                        HobbyId = h.HobbyId,
                        HobbyName = h.Hobby.HobbyName
                    }).ToList()
                };

                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = "Kullanıcı başarıyla getirildi",

                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }
    }
}