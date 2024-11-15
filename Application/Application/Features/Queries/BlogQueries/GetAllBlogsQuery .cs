using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.BlogResults;
using MediatR;

namespace Application.Features.Queries.BlogQueries
{
    public class GetAllBlogsQuery : IRequest<List<BlogResult>>
    {

    }
}