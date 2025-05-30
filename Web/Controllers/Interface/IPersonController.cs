using Microsoft.AspNetCore.Mvc;
using Entity.Model;
using Entity.Dtos.Person;

namespace Web.Controllers.Interface
{
    public interface IPersonController : IGenericController<PersonDto, Person>
    {
        Task<IActionResult> UpdatePartialPerson(int id, int personId, UpdatePersonDto dto);
        Task<IActionResult> DeleteLogicPerson(int id);
    }
}
