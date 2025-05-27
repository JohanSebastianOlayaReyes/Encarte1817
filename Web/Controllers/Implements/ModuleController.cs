using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.ModuleDto;
using Entity.Model;
using Web.Controllers.Interface;
using Business.Interfaces;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    public class ModuleController : GenericController<ModuleDto, Module>, IModuleController
    {
        private readonly IModuleBusiness _moduleBusiness;

        public ModuleController(IModuleBusiness moduleBusiness, ILogger<ModuleController> logger)
            : base(moduleBusiness, logger)
        {
            _moduleBusiness = moduleBusiness;
        }

        protected override int GetEntityId(ModuleDto dto)
        {
            return dto.Id;
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePartialModule(int id, int moduleId, [FromBody] UpdateModuleDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _moduleBusiness.UpdatePartialModuleAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente módulo: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente módulo: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicModule(int id)
        {
            try
            {
                var dto = new DeleteLogiModuleDto { Id = id, Status = false };
                var result = await _moduleBusiness.DeleteLogicModuleAsync(dto);
                if (!result)
                    return NotFound($"Módulo con ID {id} no encontrado");

                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente módulo: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente módulo con ID {id}: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
