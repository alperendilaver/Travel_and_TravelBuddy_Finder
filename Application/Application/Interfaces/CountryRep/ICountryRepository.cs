using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.CountryRep
{
    public interface ICountryRepository
    {
        public Task<List<Country>> GetCountriesWithCitiesAsync();
        public Task<Country> GetCountryWithCitiesAsync(int id);
    }
}