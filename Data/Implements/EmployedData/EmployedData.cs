using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements.EmployedData
{
    public class EmployedData : BaseModelData<Employed>, IEmployedData
    {
        public EmployedData(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var employed = await _context.Set<Employed>().FindAsync(id);
            if (employed == null)
                return false;

            employed.Status = active;
            _context.Entry(employed).Property(e => e.Status).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(Employed employed)
        {
            var existingEmployed = await _context.Employeds.FindAsync(employed.Id);
            if (existingEmployed == null) return false;
            _context.Employeds.Update(existingEmployed);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
