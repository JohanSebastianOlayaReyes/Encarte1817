using Entity.Dtos.CityDto;
using Entity.Model;

namespace Business.Interfaces
{
    public interface ICityBusiness : IBaseBusiness<City, CityDto >
    {
        Task<bool> UpdatePartialCityAsync(UpdateCityDto dto);
        Task<bool> DeleteLogicCityAsync(DeleteLogiCityDto dto);
    }
}
