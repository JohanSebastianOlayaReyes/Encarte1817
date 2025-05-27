using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.ProviderDto;
using Entity.Model;
using Web.Controllers.Interface;
using Business.Interfaces;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    public class ProviderController : GenericController<ProviderDto, Provider>, IProviderController
    {
        private readonly IProviderBusiness _providerBusiness;

        public ProviderController(IProviderBusiness providerBusiness, ILogger<ProviderController> logger)
            : base(providerBusiness, logger)
        {
            _providerBusiness = providerBusiness;
        }

        protected override int GetEntityId(ProviderDto dto)
        {
            return dto.Id;
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePartialProvider(int id, int providerId, [FromBody] UpdateProviderDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _providerBusiness.UpdatePartialProviderAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente proveedor: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente proveedor: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicProvider(int id)
        {
            try
            {
                var dto = new DeleteLogiProviderDto { Id = id, Status = false };
                var result = await _providerBusiness.DeleteLogicProviderAsync(dto);
                if (!result)
                    return NotFound($"Proveedor con ID {id} no encontrado");

                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente proveedor: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente proveedor con ID {id}: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
