using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Features.Results.UserResults;

namespace Application.Features.Handlers.UserHandlers
{
    public class CheckAuthHandler
    {
        public AuthResult Handle(ClaimsPrincipal user)
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            var FullName = user.FindFirstValue(ClaimTypes.Name);
            var role = user.FindFirstValue(ClaimTypes.Role);
            var result = new AuthResult
            {
                FullName = FullName,
                Id = userId,
                Role = role,
            };
            return result;
        }
    }
}