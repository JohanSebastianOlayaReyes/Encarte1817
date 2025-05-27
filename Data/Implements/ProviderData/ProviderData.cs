using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements.ProviderData
{
    public class ProviderData : BaseModelData<Provider>, IProviderData
    {
        public ProviderData(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var provider = await _context.Set<Provider>().FindAsync(id);
            if (provider == null)
                return false;

            provider.Status = active;
            _context.Entry(provider).Property(p => p.Status).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(Provider provider)
        {
            var existingProvider = await _context.Providers.FindAsync(provider.Id);
            if (existingProvider == null) return false;
            _context.Providers.Update(existingProvider);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
