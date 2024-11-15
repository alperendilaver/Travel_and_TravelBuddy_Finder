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
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, GeneralResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;
        public RegisterUserHandler(UserManager<AppUser> userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<GeneralResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                UserName = request.UserName,
                Email = request.Email,
                GovernmentId = request.GovernmentId,
                Visa = request.Visa,
                Budget = request.Budget,
                Passpart = request.Passport,
                Gender = request.Gender
            };

            try
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = $"http://localhost:3000/confirm-email?userId={user.Id}&token={Uri.EscapeDataString(token)}";
                    await _emailService.SendEmailAsync(user.Email, "Hesap Onayı", $"Lütfen hesabınızı doğrulamak için <a href='{callbackUrl}'>buraya tıklayın</a>");
                    var roleresult = await _userManager.AddToRoleAsync(user, "Member");
                    return new GeneralResponse
                    {
                        IsSucceded = true,
                        Message = "Kullanıcı başarıyla oluşturuldu",

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
