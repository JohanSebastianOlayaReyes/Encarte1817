using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.ProviderDto
{
    public class UpdateProviderDto : Base.BaseInfoDto
    {
        public string CompanyName { get; set; }
        public string IdentificationNumber { get; set; }
        public TypeIdentification TypeIdentification { get; set; }
        public int EmployedId { get; set; }
    }
}
