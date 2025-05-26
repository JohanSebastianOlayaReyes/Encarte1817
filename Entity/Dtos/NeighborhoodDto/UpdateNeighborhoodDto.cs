using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.NeighborhoodDto
{
    public class UpdateNeighborhoodDto : Base.BaseInfoDto
    {
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public string Description { get; set; }
        public int CityId { get; set; }
    }
}
