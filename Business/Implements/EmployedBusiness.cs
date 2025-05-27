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
using Entity.Dtos.Employed;

namespace Business.Implements
{
    /// <summary>
    /// Contiene la lógica de negocio de los métodos específicos para la entidad Employed.
    /// Extiende BaseBusiness heredando la lógica de negocio de los métodos base.
    /// </summary>
    public class EmployedBusiness : BaseBusiness<Employed, EmployedDto>, IEmployedBusiness
    {
        ///<summary>Proporciona acceso a los métodos de la capa de datos de empleados</summary>
        private readonly IEmployedData _employedData;

        /// <summary>
        /// Constructor de la clase EmployedBusiness
        /// Inicializa una nueva instancia con las dependencias necesarias para operar con empleados.
        /// </summary>
        public EmployedBusiness(IEmployedData employedData, IMapper mapper, ILogger<EmployedBusiness> logger, IGenericIHelpers helpers)
            : base(employedData, mapper, logger, helpers)
        {
            _employedData = employedData;
        }

        ///<summary>
        /// Actualiza parcialmente un empleado en la base de datos
        /// </summary>
        public async Task<bool> UpdatePartialEmployedAsync(UpdateEmployedDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var employed = _mapper.Map<Employed>(dto);

            var result = await _employedData.UpdatePartial(employed); // esto ya retorna bool
            return result;
        }

        ///<summary>
        /// Desactiva un empleado en la base de datos
        /// </summary>
        public async Task<bool> DeleteLogicEmployedAsync(DeleteLogiEmployedDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del empleado es inválido");

            var exists = await _employedData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("employed", dto.Id);

            return await _employedData.ActiveAsync(dto.Id, dto.Status);
        }
    }
}
