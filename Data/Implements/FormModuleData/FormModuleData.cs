using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements.FormModuleData
{
    public class FormModuleData : BaseModelData<FormModule>, IFormModuleData
    {
        public FormModuleData(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var formModule = await _context.Set<FormModule>().FindAsync(id);
            if (formModule == null)
                return false;

            formModule.Status = active;
            _context.Entry(formModule).Property(fm => fm.Status).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(FormModule formModule)
        {
            var existingFormModule = await _context.FormModules.FindAsync(formModule.Id);
            if (existingFormModule == null) return false;
            _context.FormModules.Update(existingFormModule);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
