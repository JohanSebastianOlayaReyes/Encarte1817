using Entity.Enums;
using Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Person : BaseInfo
    {
        public TypeIdentification TypeIdentification { get; set; }
        public string NumberIdientification { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
