using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.UserCommands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Handlers.UserHandlers
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, IdentityResult>
    {
        private readonly UserManager<AppUser> _userManager;

        public ResetPasswordCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "Kullanıcı bulunamadı" });
            var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
            return result;
        }
    }
}