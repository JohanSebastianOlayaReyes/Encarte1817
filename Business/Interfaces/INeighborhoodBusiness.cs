using Business.Interfaces;
using Entity.Dtos.NeighborhoodDto;
using Entity.Model;

namespace Business.Interfaces
{
    ///<summary>
    /// Define los métodos de negocio específicos para la gestión de barrios (Neighborhood).
    /// Hereda operaciones CRUD genéricas de <see cref="IBaseBusiness{Neighborhood, NeighborhoodDto}"/>.
    ///</summary>
    public interface INeighborhoodBusiness : IBaseBusiness<Neighborhood, NeighborhoodDto>
    {
        /// <summary>
        /// Actualiza parcialmente los datos de un barrio.
        /// </summary>
        /// <param name="dto">Objeto que contiene los datos actualizados del barrio.</param>
        ///<returns>True si la actualización fue exitosa; de lo contrario false</returns>
        Task<bool> UpdatePartialNeighborhoodAsync(UpdateNeighborhoodDto dto);

        /// <summary>
        /// Realiza un borrado lógico del barrio, marcándolo como inactivo en lugar de eliminarlo físicamente.
        /// </summary>
        /// <param name="dto">DTO con el ID y estado del barrio a desactivar.</param>
        ///<returns>True si el borrado lógico fue exitoso; de lo contrario false</returns>
        Task<bool> DeleteLogicNeighborhoodAsync(DeleteLogiNeighborhoodDto dto);
    }
}
