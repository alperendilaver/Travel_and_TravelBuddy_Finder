using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.UserQueries;
using Application.Features.Results.UserResults;
using Application.Interfaces.UserRepository;
using MediatR;

namespace Application.Features.Handlers.UserHandlers
{
    public class GetRoleNameQueryHandler : IRequestHandler<GetRoleNameQuery, GetRoleNameQueryResult>
    {
        private readonly IUserRepository _repository;
        public GetRoleNameQueryHandler(IUserRepository userRepository)
        {
            _repository = userRepository;
        }
        public async Task<GetRoleNameQueryResult> Handle(GetRoleNameQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetRole(request.UserId);
        }
    }
}