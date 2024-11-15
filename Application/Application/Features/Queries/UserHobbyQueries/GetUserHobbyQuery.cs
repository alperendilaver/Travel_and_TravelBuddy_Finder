using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.UserHobbyResults;
using MediatR;

namespace Application.Features.Queries.UserHobbyQueries
{
    public class GetUserHobbyQuery : IRequest<UserHobbyResult>
    {
        public int UserHobbyId { get; set; }
    }
}