using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.NotificationCommands;
using Application.Features.Results.General;
using Application.Interfaces.IEmailService;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.NotificationHandlers
{
    public class MatchNotificationCommandHandler : IRequestHandler<MatchNotificationCommand, GeneralResponse>
    {
        private readonly IRepository<Notification> _repository;
        private readonly IEmailService _emailService;

        public MatchNotificationCommandHandler(IRepository<Notification> repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public async Task<GeneralResponse> Handle(MatchNotificationCommand request, CancellationToken cancellationToken)
        {
            var response = new GeneralResponse();
            try
            {
                await _repository.CreateAsync(new Notification { CreatedAt = DateTime.Now, IsRead = false, Message = request.Message, Subject = request.Subject, ReceiverUserId = request.ReceiverUserId });

                await _emailService.SendEmailAsync(request.ReceiverUserEmail, request.Subject, request.Message);
                response.IsSucceded = true;
                response.Message = "Bildirim başarılı şekilde eklendi ve gönderildi";
            }
            catch (System.Exception ex)
            {
                response.Message += ex.Message;
                response.IsSucceded = false;
            }

            return response;
        }
    }
}