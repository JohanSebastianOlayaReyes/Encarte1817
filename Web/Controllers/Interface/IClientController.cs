using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.ClientDto;
using Entity.Model;

namespace Web.Controllers.Interface
{
    public interface IClientController : IGenericController<ClientDto, Client>
    {
        Task<IActionResult> UpdatePartialClient(int id, int clientId, UpdateClientDto dto);
        Task<IActionResult> DeleteLogicClient(int id);
    }
}
