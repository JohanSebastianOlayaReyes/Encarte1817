using AutoMapper;
using Microsoft.Extensions.Logging;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Model;
using Utilities.Exceptions;
using Utilities.Interfaces;
using Entity.Dtos.ClientDto;

namespace Business.Implements
{
    /// <summary>
    /// Contiene la lógica de negocio específica para la entidad Client.
    /// Hereda la lógica base desde BaseBusiness.
    /// </summary>
    public class ClientBusiness : BaseBusiness<Client, ClientDto>, IClientBusiness
    {
        private readonly IClientData _clientData;

        public ClientBusiness(IClientData clientData, IMapper mapper, ILogger<ClientBusiness> logger, IGenericIHelpers helpers)
            : base(clientData, mapper, logger, helpers)
        {
            _clientData = clientData;
        }

        /// <summary>
        /// Actualiza parcialmente un cliente.
        /// </summary>
        public async Task<bool> UpdatePartialClientAsync(UpdateClientDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var client = _mapper.Map<Client>(dto);
            var result = await _clientData.UpdatePartial(client);
            return result;
        }

        /// <summary>
        /// Activa o desactiva un cliente (eliminación lógica).
        /// </summary>
        public async Task<bool> DeleteLogicClientAsync(DeleteLogiClientDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del cliente es inválido.");

            var exists = await _clientData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("Client", dto.Id);

            return await _clientData.ActiveAsync(dto.Id, dto.Status);
        }
    }
}
