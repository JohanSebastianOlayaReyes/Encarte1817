using AutoMapper;
using Microsoft.Extensions.Logging;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Model;
using Utilities.Exceptions;
using Utilities.Interfaces;
using Entity.Dtos.Person;

namespace Business.Implements
{
    /// <summary>
    /// Contiene la lógica de negocio específica para la entidad Person.
    /// Hereda la lógica base desde BaseBusiness.
    /// </summary>
    public class PersonBusiness : BaseBusiness<Person, PersonDto>, IPersonBusiness
    {
        private readonly IPersonData _personData;

        public PersonBusiness(IPersonData personData, IMapper mapper, ILogger<PersonBusiness> logger, IGenericIHelpers helpers)
            : base(personData, mapper, logger, helpers)
        {
            _personData = personData;
        }

        /// <summary>
        /// Actualiza parcialmente una persona.
        /// </summary>
        public async Task<bool> UpdatePartialAsync(UpdatePersonDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var person = _mapper.Map<Person>(dto);
            var result = await _personData.UpdatePartial(person);
            return result;
        }

        /// <summary>
        /// Activa o desactiva una persona (eliminación lógica).
        /// </summary>
        public async Task<bool> DeleteLogicAsync(DeleteLogiPersonDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID de la persona es inválido.");

            var exists = await _personData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("Person", dto.Id);

            return await _personData.ActiveAsync(dto.Id, dto.Status);
        }
    }
}
