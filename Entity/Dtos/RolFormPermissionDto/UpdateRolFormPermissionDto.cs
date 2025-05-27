using Entity.Model;
using Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.RolFormPermissionDto
{
    public class UpdateRolFormPermissionDto : BaseEntity
    {
        public int RoleId { get; set; }
        public int FormId { get; set; }
        public int PermissionId { get; set; }
    }
}
