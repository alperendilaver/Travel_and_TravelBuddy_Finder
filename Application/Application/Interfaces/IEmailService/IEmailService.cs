using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Interfaces.IEmailService
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string message);
    }
}