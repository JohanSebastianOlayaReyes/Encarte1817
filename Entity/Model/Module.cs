using System;
using System.Collections.Generic;
using System.Linq;
using Entity.Model.Base;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Module : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Route { get; set; }
        public ICollection<FormModule> FormModules { get; set; }
    }
}
