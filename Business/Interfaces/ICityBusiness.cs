using Entity.Dtos.CityDto;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICityBusiness : IBaseBusiness<City, CityDto >
    {
        Task<bool> UpdatePartialCityAsync(UpdateCityDto dto);
        Task<bool> DeleteLogicCityAsync(DeleteLogiCityDto dto);
    }
}
