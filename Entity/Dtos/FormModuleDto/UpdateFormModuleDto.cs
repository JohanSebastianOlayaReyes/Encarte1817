using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.FormModuleDto
{
    public class UpdateFormModuleDto : Base.BaseDto
    {
        public int FormId { get; set; }
        public int ModuleId { get; set; }
    }
}
