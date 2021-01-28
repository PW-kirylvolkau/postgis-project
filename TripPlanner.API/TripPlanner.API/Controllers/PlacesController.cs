using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TripPlanner.API.Models;
using TripPlanner.API.Repository;

namespace TripPlanner.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PlacesController : ControllerBase
    {
        private readonly PlaceRepository _placeRepository;
        private readonly PointRepository _pointRepository;
        public PlacesController(
            PlaceRepository placeRepository, 
            PointRepository pointRepository
            )
        {
            _placeRepository = placeRepository;
            _pointRepository = pointRepository;
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
        [HttpGet("{pointId}")]
        public async Task<List<Place>> GetAllForPoint(int pointId)
        {
            var point = await _pointRepository.GetById(pointId);
            return point.Places.ToList();
        }

        [HttpGet]
        public async Task<List<Place>> GetAll()
        {
            var allPlaces = await _placeRepository.GetAll();
            return allPlaces.ToList();
        }
        
        // TODO
        // * AddPlaceToPoint(int pointId)
        [HttpPost]
        public async Task<IActionResult> AddPlace(int pointId, Place place)
        {
            if(!(await _pointRepository.Exists(pointId))) return NotFound();

            var point = await _pointRepository.GetById(pointId);

            if(point.Places.Contains(place)) return BadRequest();

            var created = await CreatePlace(place);

            point.Places.Add(place);

            return Ok(created);
        }

        public async Task<IActionResult> CreatePlace(Place place)
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