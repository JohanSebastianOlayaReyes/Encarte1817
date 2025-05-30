using AutoMapper;
using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Context;
using Entity.Dtos.CityDto;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements.CityData
{
    public class CityData : BaseModelData<City> , ICityData
    {
        public CityData(ApplicationDbContext context) : base(context) 
        { 
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var city = await _context.Set<City>().FindAsync(id);
            if (city == null)
                return false;

            city.Status = active;
            _context.Entry(city).Property(c => c.Status).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }

        private readonly IMapper _mapper;

        public CityData(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<bool> UpdatePartial(UpdateCityDto cityDto)
        {
            var existingCity = await _context.Cities.FindAsync(cityDto.Id);
            if (existingCity == null) return false;

            _mapper.Map(cityDto, existingCity);

            await _context.SaveChangesAsync();
            return true;
        }

    }
}
