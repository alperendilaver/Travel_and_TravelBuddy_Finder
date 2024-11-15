using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.HotelRep
{
    public interface IHotelRepository
    {
        public Task<Hotel> GetHotelWithCityAsync(int hotelId);
        public Task<List<Hotel>> GetAllHotelsWithCityAsync();
        public Task<List<Hotel>> GetHotelsByIdAsync(List<int> ints);
    }
}