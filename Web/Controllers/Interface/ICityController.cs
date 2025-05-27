using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.CityDto;
using Entity.Model;

namespace Web.Controllers.Interface
{
    public interface ICityController : IGenericController<CityDto, City>
    {
        Task<IActionResult> UpdatePartialCity(int id, int cityId, UpdateCityDto dto);
        Task<IActionResult> DeleteLogicCity(int id);
    }
}
