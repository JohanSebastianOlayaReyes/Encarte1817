using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.NeighborhoodDto;
using Entity.Model;

namespace Web.Controllers.Interface
{
    public interface INeighborhoodController : IGenericController<NeighborhoodDto, Neighborhood>
    {
        Task<IActionResult> UpdatePartialNeighborhood(int id, int neighborhoodId, UpdateNeighborhoodDto dto);
        Task<IActionResult> DeleteLogicNeighborhood(int id);
    }
}
