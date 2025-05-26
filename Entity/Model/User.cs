using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Base;

namespace Entity.Model
{
    public class User : BaseInfo
    {
        public string Password { get; set; }
        public IEnumerable<RolUser> RolUsers { get; set; }
        public  int PersonId {get; set;}
        public Person Person { get; set; }
    }
}
