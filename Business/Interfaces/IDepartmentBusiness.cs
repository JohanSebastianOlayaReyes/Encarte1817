using Business.Interfaces;
using Entity.Dtos.DeparmentDto;

using Entity.Model;

namespace Business.Interfaces
{
    /// <summary>
    /// Define los métodos de negocio específicos para la gestión de departamentos.
    /// Hereda operaciones CRUD genéricas de <see cref="IBaseBusiness{Department, DepartmentDto}"/>.
    /// </summary>
    public interface IDepartmentBusiness : IBaseBusiness<Deparment, DeparmentDto>
    {
        /// <summary>
        /// Actualiza parcialmente los datos de un departamento.
        /// </summary>
        /// <param name="dto">Objeto que contiene los datos actualizados del departamento, como nombre o estado.</param>
        /// <returns>True si la actualización fue exitosa; de lo contrario false.</returns>
        Task<bool> UpdatePartialDepartmentAsync(UpdateDeparmentDto dto);

        /// <summary>
        /// Realiza un borrado lógico del departamento, marcándolo como inactivo en lugar de eliminarlo físicamente.
        /// </summary>
        /// <param name="dto">DTO con el ID y el estado a aplicar.</param>
        /// <returns>True si el borrado lógico fue exitoso; de lo contrario false.</returns>
        Task<bool> DeleteLogicDepartmentAsync(DeleteLogiDeparmentDto dto);
    }
}
