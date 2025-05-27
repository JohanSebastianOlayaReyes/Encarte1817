using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.FormModuleDto;
using Entity.Model;

namespace Web.Controllers.Interface
{
    public interface IFormModuleController : IGenericController<FormModuleDto, FormModule>
    {
        Task<IActionResult> UpdatePartialFormModule(int id, int formModuleId, UpdateFormModuleDto dto);
        Task<IActionResult> DeleteLogicFormModule(int id);
    }
}
