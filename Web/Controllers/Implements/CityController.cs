using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.CityDto;
using Entity.Model;
using Web.Controllers.Interface;
using Business.Interfaces;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    public class CityController : GenericController<CityDto, City>, ICityController
    {
        private readonly ICityBusiness _cityBusiness;

        public CityController(ICityBusiness cityBusiness, ILogger<CityController> logger)
            : base(cityBusiness, logger)
        {
            _cityBusiness = cityBusiness;
        }

        protected override int GetEntityId(CityDto dto)
        {
            return dto.Id;
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePartialCity(int id, int cityId, [FromBody] UpdateCityDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _cityBusiness.UpdatePartialCityAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente ciudad: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente ciudad: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicCity(int id)
        {
            try
            {
                var dto = new DeleteLogiCityDto { Id = id, Status = false };
                var result = await _cityBusiness.DeleteLogicCityAsync(dto);
                if (!result)
                    return NotFound($"Ciudad con ID {id} no encontrada");

                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente ciudad: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente ciudad con ID {id}: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
