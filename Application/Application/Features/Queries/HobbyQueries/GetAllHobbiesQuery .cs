using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.HobbyResults;
using MediatR;

namespace Application.Features.Queries.HobbyQueries
{
    public class GetAllHobbiesQuery : IRequest<List<HobbyResult>> { }
}