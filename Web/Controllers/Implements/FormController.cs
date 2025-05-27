using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.FormDto;
using Entity.Model;
using Web.Controllers.Interface;
using Business.Interfaces;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    public class FormController : GenericController<FormDto, Form>, IFormController
    {
        private readonly IFormBusiness _formBusiness;

        public FormController(IFormBusiness formBusiness, ILogger<FormController> logger)
            : base(formBusiness, logger)
        {
            _formBusiness = formBusiness;
        }

        protected override int GetEntityId(FormDto dto)
        {
            return dto.Id;
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePartialForm(int id, int formId, [FromBody] UpdateFormDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _formBusiness.UpdatePartialFormAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente formulario: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente formulario: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicForm(int id)
        {
            try
            {
                var dto = new DeleteLogiFormDto { Id = id, Status = false };
                var result = await _formBusiness.DeleteLogicFormAsync(dto);
                if (!result)
                    return NotFound($"Formulario con ID {id} no encontrado");

                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente formulario: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente formulario con ID {id}: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
