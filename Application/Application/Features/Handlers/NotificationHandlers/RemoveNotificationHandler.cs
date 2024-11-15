using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.NotificationCommands;
using Application.Features.Results.General;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.NotificationHandlers
{
    public class RemoveNotificationHandler : IRequestHandler<RemoveNotificationCommand, GeneralResponse>
    {
        private readonly IRepository<Notification> _repository;

        public RemoveNotificationHandler(IRepository<Notification> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(RemoveNotificationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.NotificationId);
            var response = new GeneralResponse();
            try
            {
                await _repository.RemoveAsync(entity);
                response.IsSucceded = true;
                response.Message = "Bildirim Silindi";
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