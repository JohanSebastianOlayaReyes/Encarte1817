using Entity.Dtos.Person;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IPersonBusiness : IBaseBusiness<Person, PersonDto>
    {
        Task<bool> UpdatePartialAsync(UpdatePersonDto dto);
        Task<bool> DeleteLogicAsync(DeleteLogiPersonDto dto);
    }
}
