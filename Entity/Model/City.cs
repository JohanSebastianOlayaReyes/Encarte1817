using Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class City : BaseEntity 
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<Deparment> Deparments { get; set; }
        public ICollection<Neighborhood> Neighborhoods { get; set; }
    }
}
