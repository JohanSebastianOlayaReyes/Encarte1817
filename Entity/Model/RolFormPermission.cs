using Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class RolFormPermission : BaseEntity
    {
        public int RoleId { get; set; }
        public Rol Role { get; set; }

        public int FormId { get; set; }
        public Form Form { get; set; }

        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
