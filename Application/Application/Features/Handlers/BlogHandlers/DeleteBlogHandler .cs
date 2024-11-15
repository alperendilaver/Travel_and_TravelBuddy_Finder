using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.BlogCommands;
using Application.Features.Results.General;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.BlogHandlers
{
    public class DeleteBlogHandler : IRequestHandler<DeleteBlogCommand, GeneralResponse>
    {
        private readonly IRepository<Blog> _repository;

        public DeleteBlogHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Blog = await _repository.GetByIdAsync(request.BlogId);
                if (Blog == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Şehir bulunamadı" };
                }

                await _repository.RemoveAsync(Blog);

                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = $"{Blog.BlogName} başarılı şekilde silindi"
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }
    }
}