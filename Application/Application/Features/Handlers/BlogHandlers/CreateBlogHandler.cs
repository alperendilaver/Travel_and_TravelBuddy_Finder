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
    public class CreateBlogHandler : IRequestHandler<CreateBlogCommand, GeneralResponse>
    {
        private readonly IRepository<Blog> _repository;

        public CreateBlogHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var Blog = new Blog
            {
                BlogName = request.BlogName,
                Context = request.Context,
            };
            try
            {
                await _repository.CreateAsync(Blog);
                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = $"{Blog.BlogName} başarılı şekilde oluşturuldu"
                };
            }
            catch (System.Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }


    }

}