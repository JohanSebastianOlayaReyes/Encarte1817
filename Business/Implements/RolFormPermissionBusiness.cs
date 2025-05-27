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
using Entity.Dtos.RolFormPermissionDto;

namespace Business.Implements
{
    /// <summary>
    /// Contiene la lógica de negocio de los métodos específicos para la entidad RolFormPermission.
    /// Extiende BaseBusiness heredando la lógica de negocio de los métodos base.
    /// </summary>
    public class RolFormPermissionBusiness : BaseBusiness<RolFormPermission, RolFormPermissionDto>, IRolFormPermissionBusiness
    {
        ///<summary>Proporciona acceso a los métodos de la capa de datos de RolFormPermission</summary>
        private readonly IRolFormPermissionData _rolFormPermissionData;

        /// <summary>
        /// Constructor de la clase RolFormPermissionBusiness
        /// Inicializa una nueva instancia con las dependencias necesarias para operar con RolFormPermission.
        /// </summary>
        public RolFormPermissionBusiness(IRolFormPermissionData rolFormPermissionData, IMapper mapper, ILogger<RolFormPermissionBusiness> logger, IGenericIHelpers helpers)
            : base(rolFormPermissionData, mapper, logger, helpers)
        {
            _rolFormPermissionData = rolFormPermissionData;
        }

        ///<summary>
        /// Actualiza parcialmente un RolFormPermission en la base de datos
        /// </summary>
        public async Task<bool> UpdatePartialRolFormPermissionAsync(UpdateRolFormPermissionDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var rolFormPermission = _mapper.Map<RolFormPermission>(dto);

            var result = await _rolFormPermissionData.UpdatePartial(rolFormPermission); // esto ya retorna bool
            return result;
        }

        ///<summary>
        /// Desactiva un RolFormPermission en la base de datos
        /// </summary>
        public async Task<bool> DeleteLogicRolFormPermissionAsync(DeleteLogiRolFormPermissionDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del RolFormPermission es inválido");

            var exists = await _rolFormPermissionData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("rolFormPermission", dto.Id);

            return await _rolFormPermissionData.ActiveAsync(dto.Id, dto.Status);
        }
    }
}
