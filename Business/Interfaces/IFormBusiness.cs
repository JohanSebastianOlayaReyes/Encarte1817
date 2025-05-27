using Business.Interfaces;
using Entity.Dtos.FormDto;
using Entity.Model;

namespace Business.Interfaces
{
    ///<summary>
    /// Define los métodos de negocio específicos para la gestión de formularios.
    /// Hereda operaciones CRUD genéricas de <see cref="IBaseBusiness{Form, FormDto}"/>.
    ///</summary>
    public interface IFormBusiness : IBaseBusiness<Form, FormDto>
    {
        /// <summary>
        /// Actualiza parcialmente los datos de un formulario.
        /// </summary>
        /// <param name="dto">Objeto que contiene los datos actualizados del formulario.</param>
        ///<returns>True si la actualización fue exitosa; de lo contrario false</returns>
        Task<bool> UpdatePartialFormAsync(UpdateFormDto dto);

        /// <summary>
        /// Realiza un borrado lógico del formulario, marcándolo como inactivo en lugar de eliminarlo físicamente.
        /// </summary>
        /// <param name="dto">DTO con el ID y estado del formulario a desactivar.</param>
        ///<returns>True si el borrado lógico fue exitoso; de lo contrario false</returns>
        Task<bool> DeleteLogicFormAsync(DeleteLogiFormDto dto);
    }
}
