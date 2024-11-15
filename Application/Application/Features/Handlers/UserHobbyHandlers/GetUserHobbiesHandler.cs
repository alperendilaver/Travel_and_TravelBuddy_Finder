using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.UserHobbyQueries;
using Application.Features.Results.UserHobbyResults;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.UserHobbyHandlers
{
    public class GetUserHobbysHandler : IRequestHandler<GetUserHobbiesQuery, List<UserHobbyResult>>
    {
        private readonly IRepository<UserHobby> _repository;

        public GetUserHobbysHandler(IRepository<UserHobby> repository)
        {
            _repository = repository;
        }
        public async Task<List<UserHobbyResult>> Handle(GetUserHobbiesQuery request, CancellationToken cancellationToken)
        {
            var UserHobbys = await _repository.GetAllAsync();
            return UserHobbys
                .Select(c => new UserHobbyResult
                {
                    UserHobbyId = c.UserHobbyId,
                    HobbyId = c.HobbyId,
                    HobbyName = c.Hobby.HobbyName,
                    UserId = c.UserId,
                    UserName = c.User.UserName
                })
                .ToList();
        }
    }
}