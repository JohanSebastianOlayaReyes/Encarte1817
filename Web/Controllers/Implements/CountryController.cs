﻿using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.CountryDto;
using Entity.Model;
using Web.Controllers.Interface;
using Business.Interfaces;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    public class CountryController : GenericController<CountryDto, Country>, ICountryController
    {
        private readonly ICountryBusiness _countryBusiness;

        public CountryController(ICountryBusiness countryBusiness, ILogger<CountryController> logger)
            : base(countryBusiness, logger)
        {
            _countryBusiness = countryBusiness;
        }

        protected override int GetEntityId(CountryDto dto)
        {
            return dto.Id;
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePartialCountry(int id, int countryId, [FromBody] UpdateCountryDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _countryBusiness.UpdatePartialCountryAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente país: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente país: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicCountry(int id)
        {
            try
            {
                var dto = new DeleteLogiCountryDto { Id = id, Status = false };
                var result = await _countryBusiness.DeleteLogicCountryAsync(dto);
                if (!result)
                    return NotFound($"País con ID {id} no encontrado");

                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente país: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente país con ID {id}: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
