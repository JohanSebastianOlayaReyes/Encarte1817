using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.FormDto;
using Entity.Model;

namespace Web.Controllers.Interface
{
    public interface IFormController : IGenericController<FormDto, Form>
    {
        Task<IActionResult> UpdatePartialForm(int id, int formId, UpdateFormDto dto);
        Task<IActionResult> DeleteLogicForm(int id);
    }
}
