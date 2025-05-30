using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.CityDto;
using Entity.Model;
using System.Threading.Tasks;

namespace Web.Controllers.Interface
{
    public interface ICityController : IGenericController<CityDto, City>
    {
        Task<IActionResult> UpdatePartialCity(int id, UpdateCityDto dto);
        Task<IActionResult> DeleteLogicCity(int id);
    }
}
