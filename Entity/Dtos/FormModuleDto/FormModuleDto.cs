using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.FormModuleDto
{
    public class FormModuleDto : Base.BaseDto
    {
        public int FormId { get; set; }
        public int ModuleId { get; set; }
    }
}
