using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.UserCommands;
using Application.Features.Results.General;
using Application.Interfaces.IEmailService;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Handlers.UserHandlers
{
    public class ResetPasswordRequestCommandHandler : IRequestHandler<ResetPasswordRequestCommand, GeneralResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;

        public ResetPasswordRequestCommandHandler(UserManager<AppUser> userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<GeneralResponse> Handle(ResetPasswordRequestCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return new GeneralResponse { IsSucceded = false, Message = "Kullanıcı Bulunamdı" };
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetlink = $"http://localhost:3000/reset-password?token={Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(request.Email)}";
            await _emailService.SendEmailAsync(request.Email, "Şifrenizi Sıfırlayın", $"Şifrenizi sıfırlamak için bu bağlantıya tıklayın: {resetlink}");
            return new GeneralResponse { IsSucceded = true, Message = "Şifre Sıfırlama Bağlantısı Gönderildi" };
        }
    }
}