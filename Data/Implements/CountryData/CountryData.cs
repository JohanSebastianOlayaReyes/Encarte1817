using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements.CountryData
{
     public class CountryData : BaseModelData<Country> , ICountryData
    {
        public CountryData(ApplicationDbContext context) : base(context)
        { 
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var country = await _context.Set<Country>().FindAsync(id);
            if (country == null)
                return false;

            country.Status = active;
            _context.Entry(country).Property(C => C.Status).IsModified = true;

            await _context.SaveChangesAsync();
            return true;    
        }

        public async Task<bool> UpdatePartial(Country contry)
        {
            var existingCountry = await _context.Countries.FindAsync(contry.Id);
            if (existingCountry == null)
                return false;
            _context.Countries.Update(existingCountry);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
