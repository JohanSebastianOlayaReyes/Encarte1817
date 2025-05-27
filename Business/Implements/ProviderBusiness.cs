using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Entity;

using Business.Services;
using Entity.Model;
using Business.Interfaces;
using Data.Interfaces;
using Utilities.Exceptions;
using ValidationException = Utilities.Exceptions.ValidationException;
using Utilities.Interfaces;
using Entity.Dtos.ProviderDto;

namespace Business.Implements
{
    /// <summary>
    /// Contiene la lógica de negocio de los métodos específicos para la entidad Provider.
    /// Extiende BaseBusiness heredando la lógica de negocio de los métodos base.
    /// </summary>
    public class ProviderBusiness : BaseBusiness<Provider, ProviderDto>, IProviderBusiness
    {
        ///<summary>Proporciona acceso a los métodos de la capa de datos de Provider</summary>
        private readonly IProviderData _providerData;

        /// <summary>
        /// Constructor de la clase ProviderBusiness
        /// Inicializa una nueva instancia con las dependencias necesarias para operar con Provider.
        /// </summary>
        public ProviderBusiness(IProviderData providerData, IMapper mapper, ILogger<ProviderBusiness> logger, IGenericIHelpers helpers)
            : base(providerData, mapper, logger, helpers)
        {
            _providerData = providerData;
        }

        ///<summary>
        /// Actualiza parcialmente un Provider en la base de datos
        /// </summary>
        public async Task<bool> UpdatePartialProviderAsync(UpdateProviderDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var provider = _mapper.Map<Provider>(dto);

            var result = await _providerData.UpdatePartial(provider); // esto ya retorna bool
            return result;
        }

        ///<summary>
        /// Desactiva un Provider en la base de datos
        /// </summary>
        public async Task<bool> DeleteLogicProviderAsync(DeleteLogiProviderDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del proveedor es inválido");

            var exists = await _providerData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("provider", dto.Id);

            return await _providerData.ActiveAsync(dto.Id, dto.Status);
        }
    }
}
