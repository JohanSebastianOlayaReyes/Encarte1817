using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.CityDto
{
    public class CityDto : Base.BaseDto
    {
        public string Name { get; set; }
        public int CountryId { get; set; }

    }
}
