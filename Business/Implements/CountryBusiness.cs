using AutoMapper;
using Microsoft.Extensions.Logging;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Model;
using Utilities.Exceptions;
using Utilities.Interfaces;
using Entity.Dtos.CountryDto;

namespace Business.Implements
{
    /// <summary>
    /// Contiene la lógica de negocio específica para la entidad Country.
    /// Hereda la lógica base desde BaseBusiness.
    /// </summary>
    public class CountryBusiness : BaseBusiness<Country, CountryDto>, ICountryBusiness
    {
        private readonly ICountryData _countryData;

        public CountryBusiness(ICountryData countryData, IMapper mapper, ILogger<CountryBusiness> logger, IGenericIHelpers helpers)
            : base(countryData, mapper, logger, helpers)
        {
            _countryData = countryData;
        }

        /// <summary>
        /// Actualiza parcialmente un país.
        /// </summary>
        public async Task<bool> UpdatePartialCountryAsync(UpdateCountryDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var country = _mapper.Map<Country>(dto);
            var result = await _countryData.UpdatePartial(country);
            return result;
        }

        /// <summary>
        /// Activa o desactiva un país (eliminación lógica).
        /// </summary>
        public async Task<bool> DeleteLogicCountryAsync(DeleteLogiCountryDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del país es inválido.");

            var exists = await _countryData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("Country", dto.Id);

            return await _countryData.ActiveAsync(dto.Id, dto.Status);
        }
    }
}
