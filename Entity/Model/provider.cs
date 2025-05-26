using Entity.Enums;
using Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class provider : BaseEntity
    {
        public string CompanyName { get; set; }
        public string IdentificationNumber { get; set; }  
        public TypeIdentification TypeIdentification { get; set; }
        //falta 
    }
}
