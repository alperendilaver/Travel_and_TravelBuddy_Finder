using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Features.Commands.UserCommands;
using Application.Features.Results.General;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Handlers.UserHandlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponse>
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        // JWT oluşturucu servisi enjekte edilebilir
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoginHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new LoginResponse { IsSucceded = false, Message = "Kullanıcı bulunamadı." };
            }
            if (user.EmailConfirmed == false)
                return new LoginResponse { IsSucceded = false, Message = "E-Posta doğrulanmamış mail adresinize gelen bağlantı ile doğrulama işlemi gerçekleştirin" };
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (result.Succeeded)
            {
                return new LoginResponse { IsSucceded = true, Message = "Giriş başarılı.", userId = user.Id };
            }

            return new LoginResponse { IsSucceded = false, Message = "Giriş başarısız." };
        }
    }
}