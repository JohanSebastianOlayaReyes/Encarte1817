using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.Permission
{
    public class PermissionDto : Base.BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
