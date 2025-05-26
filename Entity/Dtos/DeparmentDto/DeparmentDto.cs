using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.DeparmentDto
{
    public class DeparmentDto : Base.BaseDto
    {
        public string Name { get; set; }
        public int CityId { get; set; }
    }
    
}
