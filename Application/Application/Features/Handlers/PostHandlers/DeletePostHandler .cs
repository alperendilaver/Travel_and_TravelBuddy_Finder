using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.PostCommands;
using Application.Features.Results.General;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.PostHandlers
{
    public class DeletePostHandler : IRequestHandler<DeletePostCommand, GeneralResponse>
    {
        private readonly IRepository<Post> _repository;

        public DeletePostHandler(IRepository<Post> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Post = await _repository.GetByIdAsync(request.PostId);
                if (Post == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Şehir bulunamadı" };
                }

                await _repository.RemoveAsync(Post);

                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = $"{Post.Context} başarılı şekilde silindi"
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }
    }
}