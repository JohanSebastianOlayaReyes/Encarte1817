using Business.Interfaces;
using Entity.Dtos.RolFormPermissionDto;
using Entity.Model;

namespace Business.Interfaces
{
    ///<summary>
    /// Define los métodos de negocio específicos para la gestión de permisos de formulario por rol (RolFormPermission).
    /// Hereda operaciones CRUD genéricas de <see cref="IBaseBusiness{RolFormPermission, RolFormPermissionDto}"/>.
    ///</summary>
    public interface IRolFormPermissionBusiness : IBaseBusiness<RolFormPermission, RolFormPermissionDto>
    {
        /// <summary>
        /// Actualiza parcialmente los datos de un RolFormPermission.
        /// </summary>
        /// <param name="dto">Objeto que contiene los datos actualizados.</param>
        ///<returns>True si la actualización fue exitosa; de lo contrario false</returns>
        Task<bool> UpdatePartialRolFormPermissionAsync(UpdateRolFormPermissionDto dto);

        /// <summary>
        /// Realiza un borrado lógico del RolFormPermission, marcándolo como inactivo en lugar de eliminarlo físicamente.
        /// </summary>
        /// <param name="dto">DTO con el ID y estado a desactivar.</param>
        ///<returns>True si el borrado lógico fue exitoso; de lo contrario false</returns>
        Task<bool> DeleteLogicRolFormPermissionAsync(DeleteLogiRolFormPermissionDto dto);
    }
}
