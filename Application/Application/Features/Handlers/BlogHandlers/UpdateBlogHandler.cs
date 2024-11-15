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
    public class UpdateBlogHandler : IRequestHandler<UpdateBlogCommand, GeneralResponse>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Blog = await _repository.GetByIdAsync(request.BlogId);
                if (Blog == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Şehir bulunamadı" };
                }

                Blog.BlogName = request.BlogName;
                Blog.Context = request.Context;
                await _repository.UpdateAsync(Blog);

                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = $"{Blog.BlogName} başarılı şekilde güncellendi"
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }
    }

}