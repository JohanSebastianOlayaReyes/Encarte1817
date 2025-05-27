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
using Entity.Dtos.FormModuleDto;

namespace Business.Implements
{
    /// <summary>
    /// Contiene la lógica de negocio de los métodos específicos para la entidad FormModule.
    /// Extiende BaseBusiness heredando la lógica de negocio de los métodos base.
    /// </summary>
    public class FormModuleBusiness : BaseBusiness<FormModule, FormModuleDto>, IFormModuleBusiness
    {
        ///<summary>Proporciona acceso a los métodos de la capa de datos de FormModule</summary>
        private readonly IFormModuleData _formModuleData;

        /// <summary>
        /// Constructor de la clase FormModuleBusiness
        /// Inicializa una nueva instancia con las dependencias necesarias para operar con FormModule.
        /// </summary>
        public FormModuleBusiness(IFormModuleData formModuleData, IMapper mapper, ILogger<FormModuleBusiness> logger, IGenericIHelpers helpers)
            : base(formModuleData, mapper, logger, helpers)
        {
            _formModuleData = formModuleData;
        }

        ///<summary>
        /// Actualiza parcialmente un FormModule en la base de datos
        /// </summary>
        public async Task<bool> UpdatePartialFormModuleAsync(UpdateFormModuleDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var formModule = _mapper.Map<FormModule>(dto);

            var result = await _formModuleData.UpdatePartial(formModule); // esto ya retorna bool
            return result;
        }

        ///<summary>
        /// Desactiva un FormModule en la base de datos
        /// </summary>
        public async Task<bool> DeleteLogicFormModuleAsync(DeleteLogiFormModuleDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del FormModule es inválido");

            var exists = await _formModuleData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("formModule", dto.Id);

            return await _formModuleData.ActiveAsync(dto.Id, dto.Status);
        }
    }
}
