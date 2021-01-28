using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TripPlanner.API.Models;
using TripPlanner.API.Repository;

namespace TripPlanner.API.Controllers
{
    [Authorize]
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
        // TODO
        // * GetAllForPoint(int PointId)
        [HttpGet]
        public async Task<List<Place>> GetAll()
        {
            var allPlaces = await _placeRepository.GetAll();

            return allPlaces.ToList();
        }
        
        // TODO
        // * AddPlaceToPoint(int pointId)
        [HttpPost]
        public async Task<IActionResult> CreatePoint(Place place)
        {
            var created = await _placeRepository.Add(place);

            if(created == null) return BadRequest();

            return CreatedAtAction("GetById", new {id = created.Id, created});
        }

        // remains
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var place = await _placeRepository.GetById(id);

            if(place == null) return NotFound();

            var deleted = await _placeRepository.Delete(id);
            return Ok(deleted);
        }
        
        // remains
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