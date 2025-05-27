using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.DeparmentDto;
using Entity.Model;
using Web.Controllers.Interface;
using Business.Interfaces;
using Business.Implements;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    public class DeparmentController : GenericController<DeparmentDto, Deparment>, IDeparmentController
    {
        private readonly IDepartmentBusiness _deparmentBusiness;

        public DeparmentController(IDepartmentBusiness deparmentBusiness, ILogger<DeparmentController> logger)
            : base(deparmentBusiness, logger)
        {
            _deparmentBusiness = deparmentBusiness;
        }

        protected override int GetEntityId(DeparmentDto dto)
        {
            return dto.Id;
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePartialDeparment(int id, int deparmentId, [FromBody] UpdateDeparmentDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _deparmentBusiness.UpdatePartialDepartmentAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente departamento: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente departamento: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicDeparment(int id)
        {
            try
            {
                var dto = new DeleteLogiDeparmentDto { Id = id, Status = false };
                var result = await _deparmentBusiness.DeleteLogicDepartmentAsync(dto);
                if (!result)
                    return NotFound($"Departamento con ID {id} no encontrado");

                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente departamento: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente departamento con ID {id}: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
