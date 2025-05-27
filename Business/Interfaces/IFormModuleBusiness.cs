using Business.Interfaces;
using Entity.Dtos.FormModuleDto;
using Entity.Model;

namespace Business.Interfaces
{
    ///<summary>
    /// Define los métodos de negocio específicos para la gestión de FormModule.
    /// Hereda operaciones CRUD genéricas de <see cref="IBaseBusiness{FormModule, FormModuleDto}"/>.
    ///</summary>
    public interface IFormModuleBusiness : IBaseBusiness<FormModule, FormModuleDto>
    {
        /// <summary>
        /// Actualiza parcialmente los datos de un FormModule.
        /// </summary>
        /// <param name="dto">Objeto que contiene los datos actualizados del FormModule.</param>
        ///<returns>True si la actualización fue exitosa; de lo contrario false</returns>
        Task<bool> UpdatePartialFormModuleAsync(UpdateFormModuleDto dto);

        /// <summary>
        /// Realiza un borrado lógico del FormModule, marcándolo como inactivo en lugar de eliminarlo físicamente.
        /// </summary>
        /// <param name="dto">DTO con el ID y estado del FormModule a desactivar.</param>
        ///<returns>True si el borrado lógico fue exitoso; de lo contrario false</returns>
        Task<bool> DeleteLogicFormModuleAsync(DeleteLogiFormModuleDto dto);
    }
}
