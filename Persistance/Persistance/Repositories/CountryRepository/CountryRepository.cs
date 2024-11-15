using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.CountryRep;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.CityRepository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly JourneyCloudContext _journeyCloudContext;

        public CountryRepository(JourneyCloudContext journeyCloudContext)
        {
            _journeyCloudContext = journeyCloudContext;
        }

        public Task<List<Country>> GetCountriesWithCitiesAsync()
        {
            return _journeyCloudContext.Countries.Include(x => x.Cities).ToListAsync();
        }

        public Task<Country> GetCountryWithCitiesAsync(int id)
        {
            return _journeyCloudContext.Countries.Include(x => x.Cities).FirstOrDefaultAsync(x => x.CountryId == id);
        }
    }
}