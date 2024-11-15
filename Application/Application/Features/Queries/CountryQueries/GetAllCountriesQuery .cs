using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.CountryResults;
using MediatR;

namespace Application.Features.Queries.CountryQueries
{
    public class GetAllCountriesQuery : IRequest<List<CountryResult>>
    {

    }
}