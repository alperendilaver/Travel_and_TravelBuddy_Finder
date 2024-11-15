using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.UserHobbyQueries;
using Application.Features.Results.UserHobbyResults;
using Application.Interfaces.IGeneralRepository;
using Application.Interfaces.UserHobbyRep;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.UserHobbyHandlers
{
    public class GetUserHobbyHandler : IRequestHandler<GetUserHobbyQuery, UserHobbyResult>
    {
        private readonly IUserHobbyRepository _repository;

        public GetUserHobbyHandler(IUserHobbyRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserHobbyResult> Handle(GetUserHobbyQuery request, CancellationToken cancellationToken)
        {
            var UserHobby = await _repository.GetUserHobbyAsync(request.UserHobbyId);

            return new UserHobbyResult
            {
                UserHobbyId = UserHobby.UserHobbyId,
                HobbyName = UserHobby.Hobby.HobbyName,
                UserName = UserHobby.User.UserName,
                HobbyId = UserHobby.HobbyId,
                UserId = UserHobby.UserId,
            };

        }
    }
}
