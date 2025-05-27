using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements.DepartmentData
{
    public class DepartmentData : BaseModelData<Deparment>, IDeparmentData
    {
        public DepartmentData(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var department = await _context.Set<Deparment>().FindAsync(id);
            if (department == null)
                return false;

            department.Status = active;
            _context.Entry(department).Property(d => d.Status).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(Deparment department)
        {
            var existingDepartment = await _context.Deparments.FindAsync(department.Id);
            if (existingDepartment == null) return false;
            _context.Deparments.Update(existingDepartment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
