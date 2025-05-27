using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.ProviderDto;
using Entity.Model;

namespace Web.Controllers.Interface
{
    public interface IProviderController : IGenericController<ProviderDto, Provider>
    {
        Task<IActionResult> UpdatePartialProvider(int id, int providerId, UpdateProviderDto dto);
        Task<IActionResult> DeleteLogicProvider(int id);
    }
}
