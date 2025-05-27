﻿using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.PermissionDto;
using Entity.Model;
using Web.Controllers.Interface;
using Business.Interfaces;
using Entity.Dtos.Permission;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    public class PermissionController : GenericController<PermissionDto, Permission>, IPermissionController
    {
        private readonly IPermissionBusiness _permissionBusiness;

        public PermissionController(IPermissionBusiness permissionBusiness, ILogger<PermissionController> logger)
            : base(permissionBusiness, logger)
        {
            _permissionBusiness = permissionBusiness;
        }

        protected override int GetEntityId(PermissionDto dto)
        {
            return dto.Id;
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePartialPermission(int id, int permissionId, [FromBody] UpdatePermissionDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _permissionBusiness.UpdatePartialPermissionAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente permiso: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente permiso: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicPermission(int id)
        {
            try
            {
                var dto = new DeleteLogiPermissionDto { Id = id, Status = false };
                var result = await _permissionBusiness.DeleteLogicPermissionAsync(dto);
                if (!result)
                    return NotFound($"Permiso con ID {id} no encontrado");

                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente permiso: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente permiso con ID {id}: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
