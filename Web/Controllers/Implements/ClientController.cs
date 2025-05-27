using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.ClientDto;
using Entity.Model;
using Web.Controllers.Interface;
using Business.Interfaces;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    public class ClientController : GenericController<ClientDto, Client>, IClientController
    {
        private readonly IClientBusiness _clientBusiness;

        public ClientController(IClientBusiness clientBusiness, ILogger<ClientController> logger)
            : base(clientBusiness, logger)
        {
            _clientBusiness = clientBusiness;
        }

        protected override int GetEntityId(ClientDto dto)
        {
            return dto.Id;
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePartialClient(int id, int clientId, [FromBody] UpdateClientDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _clientBusiness.UpdatePartialClientAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente cliente: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente cliente: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicClient(int id)
        {
            try
            {
                var dto = new DeleteLogiClientDto { Id = id, Status = false };
                var result = await _clientBusiness.DeleteLogicClientAsync(dto);
                if (!result)
                    return NotFound($"Cliente con ID {id} no encontrado");

                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente cliente: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente cliente con ID {id}: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
