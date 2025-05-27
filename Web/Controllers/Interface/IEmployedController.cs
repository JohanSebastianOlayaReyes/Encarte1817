using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.Employed;
using Entity.Model;

namespace Web.Controllers.Interface
{
    public interface IEmployedController : IGenericController<EmployedDto, Employed>
    {
        Task<IActionResult> UpdatePartialEmployed(int id, int employedId, UpdateEmployedDto dto);
        Task<IActionResult> DeleteLogicEmployed(int id);
    }
}
