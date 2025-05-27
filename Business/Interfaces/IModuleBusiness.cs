using Business.Interfaces;
using Entity.Dtos.ModuleDto;
using Entity.Model;

namespace Business.Interfaces
{
    ///<summary>
    /// Define los métodos de negocio específicos para la gestión de módulos.
    /// Hereda operaciones CRUD genéricas de <see cref="IBaseBusiness{Module, ModuleDto}"/>.
    ///</summary>
    public interface IModuleBusiness : IBaseBusiness<Module, ModuleDto>
    {
        /// <summary>
        /// Actualiza parcialmente los datos de un módulo.
        /// </summary>
        /// <param name="dto">Objeto que contiene los datos actualizados del módulo.</param>
        ///<returns>True si la actualización fue exitosa; de lo contrario false</returns>
        Task<bool> UpdatePartialModuleAsync(UpdateModuleDto dto);

        /// <summary>
        /// Realiza un borrado lógico del módulo, marcándolo como inactivo en lugar de eliminarlo físicamente.
        /// </summary>
        /// <param name="dto">DTO con el ID y estado del módulo a desactivar.</param>
        ///<returns>True si el borrado lógico fue exitoso; de lo contrario false</returns>
        Task<bool> DeleteLogicModuleAsync(DeleteLogiModuleDto dto);
    }
}
