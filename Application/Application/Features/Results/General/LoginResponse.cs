using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Results.General
{
    public class LoginResponse
    {
        public string userId { get; set; }
        public bool IsSucceded { get; set; }
        public string Message { get; set; }
    }
}