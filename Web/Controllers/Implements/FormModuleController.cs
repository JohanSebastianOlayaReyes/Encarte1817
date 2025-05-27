using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.FormModuleDto;
using Entity.Model;
using Web.Controllers.Interface;
using Business.Interfaces;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    public class FormModuleController : GenericController<FormModuleDto, FormModule>, IFormModuleController
    {
        private readonly IFormModuleBusiness _formModuleBusiness;

        public FormModuleController(IFormModuleBusiness formModuleBusiness, ILogger<FormModuleController> logger)
            : base(formModuleBusiness, logger)
        {
            _formModuleBusiness = formModuleBusiness;
        }

        protected override int GetEntityId(FormModuleDto dto)
        {
            return dto.Id;
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePartialFormModule(int id, int formModuleId, [FromBody] UpdateFormModuleDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _formModuleBusiness.UpdatePartialFormModuleAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente FormModule: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente FormModule: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicFormModule(int id)
        {
            try
            {
                var dto = new DeleteLogiFormModuleDto { Id = id, Status = false };
                var result = await _formModuleBusiness.DeleteLogicFormModuleAsync(dto);
                if (!result)
                    return NotFound($"FormModule con ID {id} no encontrado");

                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente FormModule: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente FormModule con ID {id}: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
