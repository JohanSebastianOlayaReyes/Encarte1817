
using Entity.Dtos.ClientDto;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IClientBusiness : IBaseBusiness<Client, ClientDto>
    {
        Task<bool> UpdatePartialClientAsync(UpdateClientDto dto);
        Task<bool> DeleteLogicClientAsync(DeleteLogiClientDto dto);
    }
}
