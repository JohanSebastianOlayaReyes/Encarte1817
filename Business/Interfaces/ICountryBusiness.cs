using Business.Interfaces;
using Entity.Dtos.CountryDto;
using Entity.Model;

namespace Business.Interfaces
{
    /// <summary>
    /// Define los métodos de negocio específicos para la gestión de países.
    /// Hereda operaciones CRUD genéricas de <see cref="IBaseBusiness{Country, CountryDto}"/>.
    /// </summary>
    public interface ICountryBusiness : IBaseBusiness<Country, CountryDto>
    {
        /// <summary>
        /// Actualiza parcialmente los datos de un país.
        /// </summary>
        /// <param name="dto">Objeto que contiene los datos actualizados del país, como nombre o estado.</param>
        /// <returns>True si la actualización fue exitosa; de lo contrario false.</returns>
        Task<bool> UpdatePartialCountryAsync(UpdateCountryDto dto);

        /// <summary>
        /// Realiza un borrado lógico del país, marcándolo como inactivo en lugar de eliminarlo físicamente.
        /// </summary>
        /// <param name="dto">DTO con el ID y el estado a aplicar.</param>
        /// <returns>True si el borrado lógico fue exitoso; de lo contrario false.</returns>
        Task<bool> DeleteLogicCountryAsync(DeleteLogiCountryDto dto);
    }
}
