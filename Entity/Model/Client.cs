using Entity.Enums;
using Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
     public class Client : BaseInfo
    {
        public TypeIdentification TypeIdentification { get; set; }
        public string NumberIdientification { get; set; }
        public int EmployedId { get; set; }
        public Employed Employed { get; set; }
        public int NeighborhoodId { get; set; }
        public Neighborhood Neighborhood { get; set; }
    }
}
