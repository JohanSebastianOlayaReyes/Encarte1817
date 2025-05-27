using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements.NeighborhoodData
{
    public class NeighborhoodData : BaseModelData<Neighborhood>, INeighborhoodData
    {
        public NeighborhoodData(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var neighborhood = await _context.Set<Neighborhood>().FindAsync(id);
            if (neighborhood == null)
                return false;

            neighborhood.Status = active;
            _context.Entry(neighborhood).Property(n => n.Status).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(Neighborhood neighborhood)
        {
            var existingNeighborhood = await _context.Neighborhoods.FindAsync(neighborhood.Id);
            if (existingNeighborhood == null) return false;
            _context.Neighborhoods.Update(existingNeighborhood);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
