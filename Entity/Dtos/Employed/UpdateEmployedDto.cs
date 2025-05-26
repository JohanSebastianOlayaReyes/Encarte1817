using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.Employed
{
    public class UpdateEmployedDto : Base.BaseInfoDto
    {
        public TypeIdentification TypeIdentification { get; set; }
        public string NumberIdientification { get; set; }
        public string JobTitle { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}
