using Microsoft.AspNetCore.Mvc;
using Entity.Model;
using Web.Controllers.Interface;
using Business.Interfaces;
using Entity.Dtos.Person;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    public class PersonController : GenericController<PersonDto, Person>, IPersonController
    {
        private readonly IPersonBusiness _personBusiness;

        public PersonController(IPersonBusiness personBusiness, ILogger<PersonController> logger)
            : base(personBusiness, logger)
        {
            _personBusiness = personBusiness;
        }

        protected override int GetEntityId(PersonDto dto)
        {
            return dto.Id;
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePartialPerson(int id, int personId, [FromBody] UpdatePersonDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _personBusiness.UpdatePartialAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente persona: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente persona: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicPerson(int id)
        {
            try
            {
                var dto = new DeleteLogiPersonDto { Id = id, Status = false };
                var result = await _personBusiness.DeleteLogicAsync(dto);
                if (!result)
                    return NotFound($"Persona con ID {id} no encontrada");

                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente persona: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente persona con ID {id}: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
