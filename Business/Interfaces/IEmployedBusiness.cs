using Business.Interfaces;
using Entity.Dtos.Employed;
using Entity.Model;

namespace Business.Interfaces
{
    ///<summary>
    /// Define los métodos de negocio específicos para la gestión de empleados.
    /// Hereda operaciones CRUD genéricas de <see cref="IBaseBusiness{Employed, EmployedDto}"/>.
    ///</summary>
    public interface IEmployedBusiness : IBaseBusiness<Employed, EmployedDto>
    {
        /// <summary>
        /// Actualiza parcialmente los datos de un empleado.
        /// </summary>
        /// <param name="dto">Objeto que contiene los datos actualizados del empleado, como nombre o estado.</param>
        ///<returns>True si la actualización fue exitosa; de lo contrario false</returns>
        Task<bool> UpdatePartialEmployedAsync(UpdateEmployedDto dto);

        /// <summary>
        /// Realiza un borrado lógico del empleado, marcándolo como inactivo en lugar de eliminarlo físicamente.
        /// </summary>
        /// <param name="dto">DTO con el ID y estado del empleado a desactivar.</param>
        ///<returns>True si el borrado lógico fue exitoso; de lo contrario false</returns>
        Task<bool> DeleteLogicEmployedAsync(DeleteLogiEmployedDto dto);
    }
}
