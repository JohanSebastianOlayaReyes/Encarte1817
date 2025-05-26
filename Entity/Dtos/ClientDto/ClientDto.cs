using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.ClientDto
{
     public class ClientDto : Base.BaseInfoDto
    {
        public TypeIdentification TypeIdentification { get; set; }
        public string NumberIdientification { get; set; }
    }
}
