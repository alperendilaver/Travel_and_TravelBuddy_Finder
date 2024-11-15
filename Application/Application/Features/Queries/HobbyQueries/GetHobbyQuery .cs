using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.HobbyResults;
using MediatR;

namespace Application.Features.Queries.HobbyQueries
{
    public class GetHobbyQuery : IRequest<HobbyResult>
    {
        public int HobbyId { get; set; }

        public GetHobbyQuery(int hobbyId)
        {
            HobbyId = hobbyId;
        }
    }
}