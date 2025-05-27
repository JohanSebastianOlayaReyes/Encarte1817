using AutoMapper;
using Microsoft.Extensions.Logging;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Model;
using Utilities.Exceptions;
using Utilities.Interfaces;
using Data.Implements.DepartmentData;
using Entity.Dtos.DeparmentDto;

namespace Business.Implements
{
    /// <summary>
    /// Contiene la lógica de negocio específica para la entidad Department.
    /// Hereda la lógica base desde BaseBusiness.
    /// </summary>
    public class DepartmentBusiness : BaseBusiness<Deparment, DeparmentDto>, IDepartmentBusiness
    {
        private readonly IDeparmentData _departmentData;

        public DepartmentBusiness(IDeparmentData departmentData, IMapper mapper, ILogger<DepartmentBusiness> logger, IGenericIHelpers helpers)
            : base(departmentData, mapper, logger, helpers)
        {
            _departmentData = departmentData;
        }

        /// <summary>
        /// Actualiza parcialmente un departamento.
        /// </summary>
        public async Task<bool> UpdatePartialDepartmentAsync(UpdateDeparmentDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var department = _mapper.Map<Deparment>(dto);
            var result = await _departmentData.UpdatePartial(department);
            return result;
        }

        /// <summary>
        /// Activa o desactiva un departamento (eliminación lógica).
        /// </summary>
        public async Task<bool> DeleteLogicDepartmentAsync(DeleteLogiDeparmentDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del departamento es inválido.");

            var exists = await _departmentData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("Department", dto.Id);

            return await _departmentData.ActiveAsync(dto.Id, dto.Status);
        }
    }
}
