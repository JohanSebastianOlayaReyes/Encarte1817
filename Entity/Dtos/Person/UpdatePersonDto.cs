using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.Person
{
    public class UpdatePersonDto : Base.BaseInfoDto
    {
        public TypeIdentification TypeIdentification { get; set; }
        public int NumberIdentification { get; set; }
    }
}
