using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.FormDto
{
   public class UpdateFormDto : Base.BaseDto
    {
        public string NameForm { get; set; }
        public string Description { get; set; }
    }
}
