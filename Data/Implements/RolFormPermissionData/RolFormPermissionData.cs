using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements.RolFormPermissionData
{
    public class RolFormPermissionData : BaseModelData<RolFormPermission>, IRolFormPermissionData
    {
        public RolFormPermissionData(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var rolFormPermission = await _context.Set<RolFormPermission>().FindAsync(id);
            if (rolFormPermission == null)
                return false;

            rolFormPermission.Status = active;
            _context.Entry(rolFormPermission).Property(rfp => rfp.Status).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(RolFormPermission rolFormPermission)
        {
            var existingRolFormPermission = await _context.RolFormPermissions.FindAsync(rolFormPermission.Id);
            if (existingRolFormPermission == null) return false;
            _context.RolFormPermissions.Update(existingRolFormPermission);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
