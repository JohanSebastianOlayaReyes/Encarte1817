using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.RolFormPermissionDto;
using Entity.Model;

namespace Web.Controllers.Interface
{
    public interface IRolFormPermissionController : IGenericController<RolFormPermissionDto, RolFormPermission>
    {
        Task<IActionResult> UpdatePartialRolFormPermission(int id, int rolFormPermissionId, UpdateRolFormPermissionDto dto);
        Task<IActionResult> DeleteLogicRolFormPermission(int id);
    }
}
