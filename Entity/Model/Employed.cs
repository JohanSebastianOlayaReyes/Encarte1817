using Entity.Enums;
using Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Employed : BaseInfo
    {
        public TypeIdentification TypeIdentification { get; set; }
        public string NumberIdientification { get; set; }
        public string JobTitle { get; set; }
        public DateTime DateOfJoining { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<Provider> Providers { get; set; }
        public object Provider { get; internal set; }
    }
}
