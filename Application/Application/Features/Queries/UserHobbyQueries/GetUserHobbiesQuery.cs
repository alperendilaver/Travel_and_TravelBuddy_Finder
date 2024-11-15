using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.UserHobbyResults;
using MediatR;

namespace Application.Features.Queries.UserHobbyQueries
{
    public class GetUserHobbiesQuery : IRequest<List<UserHobbyResult>>
    {
        public string UserId { get; set; }
    }
}