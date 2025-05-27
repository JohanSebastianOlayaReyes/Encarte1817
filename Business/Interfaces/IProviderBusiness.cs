using Business.Interfaces;
using Entity.Dtos.ProviderDto;
using Entity.Model;

namespace Business.Interfaces
{
    ///<summary>
    /// Define los métodos de negocio específicos para la gestión de proveedores (Provider).
    /// Hereda operaciones CRUD genéricas de <see cref="IBaseBusiness{Provider, ProviderDto}"/>.
    ///</summary>
    public interface IProviderBusiness : IBaseBusiness<Provider, ProviderDto>
    {
        /// <summary>
        /// Actualiza parcialmente los datos de un proveedor.
        /// </summary>
        /// <param name="dto">Objeto que contiene los datos actualizados del proveedor.</param>
        ///<returns>True si la actualización fue exitosa; de lo contrario false</returns>
        Task<bool> UpdatePartialProviderAsync(UpdateProviderDto dto);

        /// <summary>
        /// Realiza un borrado lógico del proveedor, marcándolo como inactivo en lugar de eliminarlo físicamente.
        /// </summary>
        /// <param name="dto">DTO con el ID y estado del proveedor a desactivar.</param>
        ///<returns>True si el borrado lógico fue exitoso; de lo contrario false</returns>
        Task<bool> DeleteLogicProviderAsync(DeleteLogiProviderDto dto);
    }
}
