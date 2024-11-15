using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.UserTravelHistoryResult;
using MediatR;

namespace Application.Features.Queries.UserTravelHistoryQueries
{
    public class GetUserTravelHistoryQuery : IRequest<UserTravelHistoryResult>
    {
        public int LogId { get; set; }
    }
}