using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Handlers.UserHandlers
{
    public class LogoutUserHandler
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LogoutUserHandler(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<GeneralResponse> Handle()
        {

            var response = new GeneralResponse();
            try
            {

                await _signInManager.SignOutAsync();
                response.IsSucceded = true;
                response.Message = "Çıkış Yapıldı";
            }
            catch (System.Exception ex)
            {
                response.IsSucceded = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}