using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.Employed;
using Entity.Model;
using Web.Controllers.Interface;
using Business.Interfaces;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    public class EmployedController : GenericController<EmployedDto, Employed>, IEmployedController
    {
        private readonly IEmployedBusiness _employedBusiness;

        public EmployedController(IEmployedBusiness employedBusiness, ILogger<EmployedController> logger)
            : base(employedBusiness, logger)
        {
            _employedBusiness = employedBusiness;
        }

        protected override int GetEntityId(EmployedDto dto)
        {
            return dto.Id;
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePartialEmployed(int id, int employedId, [FromBody] UpdateEmployedDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _employedBusiness.UpdatePartialEmployedAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente empleado: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente empleado: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicEmployed(int id)
        {
            try
            {
                var dto = new DeleteLogiEmployedDto { Id = id, Status = false };
                var result = await _employedBusiness.DeleteLogicEmployedAsync(dto);
                if (!result)
                    return NotFound($"Empleado con ID {id} no encontrado");

                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente empleado: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente empleado con ID {id}: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
