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
using Entity.Dtos.NeighborhoodDto;

namespace Business.Implements
{
    /// <summary>
    /// Contiene la lógica de negocio de los métodos específicos para la entidad Neighborhood.
    /// Extiende BaseBusiness heredando la lógica de negocio de los métodos base.
    /// </summary>
    public class NeighborhoodBusiness : BaseBusiness<Neighborhood, NeighborhoodDto>, INeighborhoodBusiness
    {
        ///<summary>Proporciona acceso a los métodos de la capa de datos de Neighborhood</summary>
        private readonly INeighborhoodData _neighborhoodData;

        /// <summary>
        /// Constructor de la clase NeighborhoodBusiness
        /// Inicializa una nueva instancia con las dependencias necesarias para operar con Neighborhood.
        /// </summary>
        public NeighborhoodBusiness(INeighborhoodData neighborhoodData, IMapper mapper, ILogger<NeighborhoodBusiness> logger, IGenericIHelpers helpers)
            : base(neighborhoodData, mapper, logger, helpers)
        {
            _neighborhoodData = neighborhoodData;
        }

        ///<summary>
        /// Actualiza parcialmente un Neighborhood en la base de datos
        /// </summary>
        public async Task<bool> UpdatePartialNeighborhoodAsync(UpdateNeighborhoodDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var neighborhood = _mapper.Map<Neighborhood>(dto);

            var result = await _neighborhoodData.UpdatePartial(neighborhood); // esto ya retorna bool
            return result;
        }

        ///<summary>
        /// Desactiva un Neighborhood en la base de datos
        /// </summary>
        public async Task<bool> DeleteLogicNeighborhoodAsync(DeleteLogiNeighborhoodDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del barrio es inválido");

            var exists = await _neighborhoodData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("neighborhood", dto.Id);

            return await _neighborhoodData.ActiveAsync(dto.Id, dto.Status);
        }
    }
}
