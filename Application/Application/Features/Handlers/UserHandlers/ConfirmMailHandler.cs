using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.UserCommands;
using Application.Features.Results.General;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Handlers.UserHandlers
{
    public class ConfirmMailHandler : IRequestHandler<ConfirmMailCommand, GeneralResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public ConfirmMailHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<GeneralResponse> Handle(ConfirmMailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.Where(x => x.Id == request.UserId).FirstOrDefaultAsync();
            if (user == null)
                return new GeneralResponse { IsSucceded = false, Message = "Kullanıcı Bulunamadı" };
            await _userManager.ConfirmEmailAsync(user, request.Token);
            var result = user.EmailConfirmed;
            if (result)
            {
                return new GeneralResponse { IsSucceded = true, Message = "Email Doğrulandı" };
            }
            return new GeneralResponse { IsSucceded = false, Message = "Email Doğrulanamadı" };

        }
    }
}