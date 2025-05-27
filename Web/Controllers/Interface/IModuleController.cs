using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.ModuleDto;
using Entity.Model;

namespace Web.Controllers.Interface
{
    public interface IModuleController : IGenericController<ModuleDto, Module>
    {
        Task<IActionResult> UpdatePartialModule(int id, int moduleId, UpdateModuleDto dto);
        Task<IActionResult> DeleteLogicModule(int id);
    }
}
