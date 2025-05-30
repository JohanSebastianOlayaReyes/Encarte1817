using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IPersonData : IBaseModelData<Person>
    {
        public Task<bool> ActiveAsync(int id, bool status);
        public Task<bool> UpdatePartial(Person person);
    }
}
