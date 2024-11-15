using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.HotelRep;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.HotelRepository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly JourneyCloudContext _journeyCloudContext;

        public HotelRepository(JourneyCloudContext journeyCloudContext)
        {
            _journeyCloudContext = journeyCloudContext;
        }

        public async Task<List<Hotel>> GetAllHotelsWithCityAsync()
        {
            return await _journeyCloudContext.Hotels.Include(x => x.City).ToListAsync();
        }

        public async Task<List<Hotel>> GetHotelsByIdAsync(List<int> ids)
        {
            return await _journeyCloudContext.Hotels.Where(x => ids.Contains(x.HotelId)).ToListAsync();
        }

        public Task<Hotel> GetHotelWithCityAsync(int hotelId)
        {
            return _journeyCloudContext.Hotels.Include(x => x.City).FirstOrDefaultAsync(x => x.HotelId == hotelId);
        }
    }
}