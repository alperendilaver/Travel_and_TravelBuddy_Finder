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
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, GeneralResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public DeleteUserHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<GeneralResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Kullanıcı bulunamadı" };
                }

                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return new GeneralResponse
                    {
                        IsSucceded = true,
                        Message = "Kullanıcı başarıyla silindi"
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