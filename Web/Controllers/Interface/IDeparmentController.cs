using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.DeparmentDto;
using Entity.Model;

namespace Web.Controllers.Interface
{
    public interface IDeparmentController : IGenericController<DeparmentDto, Deparment>
    {
        Task<IActionResult> UpdatePartialDeparment(int id, int deparmentId, UpdateDeparmentDto dto);
        Task<IActionResult> DeleteLogicDeparment(int id);
    }
}
