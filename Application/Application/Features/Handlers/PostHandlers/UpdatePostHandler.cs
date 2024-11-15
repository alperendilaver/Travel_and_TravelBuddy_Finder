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
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, GeneralResponse>
    {
        private readonly IRepository<Post> _repository;

        public UpdatePostHandler(IRepository<Post> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var post = await _repository.GetByIdAsync(request.PostId);
                if (post == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Şehir bulunamadı" };
                }


                post.Context = request.Context;
                post.PostedTime = DateTime.Now;
                await _repository.UpdateAsync(post);

                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = $"{post.Context} başarılı şekilde güncellendi"
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }
    }

}