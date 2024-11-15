using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.UserCommands;
using Application.Features.Results.General;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Handlers.UserHandlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, GeneralResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public UpdateUserHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<GeneralResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Kullanıcı bulunamadı" };
                }

                user.GovernmentId = request.GovernmentId;
                user.Visa = request.Visa;
                user.Budget = request.Budget;
                user.Passpart = request.Passport;
                user.Gender = request.Gender;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return new GeneralResponse
                    {
                        IsSucceded = true,
                        Message = "Kullanıcı başarıyla güncellendi"
                    };
                }
                else
                {
                    return new GeneralResponse
                    {
                        IsSucceded = false,
                        Message = string.Join(", ", result.Errors.Select(e => e.Description))
                    };
                }
            }
            catch (Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }
    }

}