using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.RolFormPermissionDto;
using Entity.Model;
using Web.Controllers.Interface;
using Business.Interfaces;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    public class RolFormPermissionController : GenericController<RolFormPermissionDto, RolFormPermission>, IRolFormPermissionController
    {
        private readonly IRolFormPermissionBusiness _rolFormPermissionBusiness;

        public RolFormPermissionController(IRolFormPermissionBusiness rolFormPermissionBusiness, ILogger<RolFormPermissionController> logger)
            : base(rolFormPermissionBusiness, logger)
        {
            _rolFormPermissionBusiness = rolFormPermissionBusiness;
        }

        protected override int GetEntityId(RolFormPermissionDto dto)
        {
            return dto.Id;
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePartialRolFormPermission(int id, int rolFormPermissionId, [FromBody] UpdateRolFormPermissionDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _rolFormPermissionBusiness.UpdatePartialRolFormPermissionAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente RolFormPermission: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente RolFormPermission: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicRolFormPermission(int id)
        {
            try
            {
                var dto = new DeleteLogiRolFormPermissionDto { Id = id, Status = false };
                var result = await _rolFormPermissionBusiness.DeleteLogicRolFormPermissionAsync(dto);
                if (!result)
                    return NotFound($"RolFormPermission con ID {id} no encontrado");

                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente RolFormPermission: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente RolFormPermission con ID {id}: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
