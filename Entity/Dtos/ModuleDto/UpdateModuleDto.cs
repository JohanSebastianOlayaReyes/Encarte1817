using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.ModuleDto
{
     public class UpdateModuleDto : Base.BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Route { get; set; }
    }
}
