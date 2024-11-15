using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using Application.Features.Results.UserResults;
using MediatR;

namespace Application.Features.Queries.UserQueries
{
    public class GetAllUsersQuery : IRequest<List<UserResult>>
    {

    }
}