using AutoMapper;
using Microsoft.Extensions.Logging;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Model;
using Entity.Dtos.CityDto;
using Utilities.Exceptions;
using Utilities.Interfaces;


namespace Business.Implements
{
    /// <summary>
    /// Contiene la lógica de negocio específica para la entidad City.
    /// Hereda la lógica base desde BaseBusiness.
    /// </summary>
    public class CityBusiness : BaseBusiness<City, CityDto>, ICityBusiness
    {
        private readonly ICityData _cityData;

        public CityBusiness(ICityData cityData, IMapper mapper, ILogger<CityBusiness> logger, IGenericIHelpers helpers)
            : base(cityData, mapper, logger, helpers)
        {
            _cityData = cityData;
        }

        /// <summary>
        /// Actualiza parcialmente una ciudad.
        /// </summary>
        public async Task<bool> UpdatePartialCityAsync(UpdateCityDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            return await _cityData.UpdatePartial(dto);
        }

        /// <summary>
        /// Activa o desactiva una ciudad (eliminación lógica).
        /// </summary>
        public async Task<bool> DeleteLogicCityAsync(DeleteLogiCityDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID de la ciudad es inválido.");

            var exists = await _cityData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("City", dto.Id);

            return await _cityData.ActiveAsync(dto.Id, dto.Status);
        }
    }
}
