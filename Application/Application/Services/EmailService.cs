using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Application.Interfaces.IEmailService;


namespace Application.Services
{
    public class EmailService : IEmailService
    {

        private string _host;
        private int _port;
        private bool _enableSSL;
        private string _username;
        private string _password;

        public EmailService(string host, int port, bool enableSSL, string username, string password)
        {
            _host = host;
            _port = port;
            _enableSSL = enableSSL;
            _username = username;
            _password = password;
        }

        public Task SendEmailAsync(string to, string subject, string message)
        {
            var client = new SmtpClient(_host, _port)
            {
                Credentials = new NetworkCredential(_username, _password),
                EnableSsl = _enableSSL
            };
            return client.SendMailAsync(new MailMessage(_username, to, subject, message) { IsBodyHtml = true });
        }
    }
}