using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.CountryDto;
using Entity.Model;

namespace Web.Controllers.Interface
{
    public interface ICountryController : IGenericController<CountryDto, Country>
    {
        Task<IActionResult> UpdatePartialCountry(int id, int countryId, UpdateCountryDto dto);
        Task<IActionResult> DeleteLogicCountry(int id);
    }
}
