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
            var places = await _placeRepository.GetAll();
            var pointPlaces = places.Where(p => p.PointId == pointId);
            return pointPlaces.ToList();
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
            var places = await _placeRepository.GetAll();
            var pointPlaces =  places.Where(p => p.PointId == pointId);

            if(pointPlaces.Contains(place)) return BadRequest();

            place.PointId = pointId;

            var created = await CreatePlace(place);

            return Ok(created);
        }
        private async Task<Place> CreatePlace(Place place)
        {
            var created = await _placeRepository.Add(place);
            return created;
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