using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripPlanner.API.Models;
using TripPlanner.API.Repository;

namespace TripPlanner.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlacesController : ControllerBase
    {
        private readonly PlaceRepository _placeRepository;
        public PlacesController(PlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var place = await _placeRepository.GetById(id);

            if(place == null) return NotFound();

            return Ok(place);
        }

        [HttpGet]
        public async Task<List<Place>> GetAll()
        {
            var allPlaces = await _placeRepository.GetAll();

            return allPlaces.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePoint(Place place)
        {
            var created = await _placeRepository.Add(place);

            if(created == null) return BadRequest();

            return CreatedAtAction("GetById", new {id = created.Id, created});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var place = await _placeRepository.GetById(id);

            if(place == null) return NotFound();

            var deleted = await _placeRepository.Delete(id);
            return Ok(deleted);
        }

        [HttpPut(template: "{id}")]
        public async Task<IActionResult> Update(int id, Place model)
        {
            var place = await _placeRepository.GetById(model.Id);

            if(place == null) return NotFound();

            var updated = await _placeRepository.Update(model);

            return Ok(updated);
        }
    }
}