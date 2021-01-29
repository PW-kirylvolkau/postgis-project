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
    public class PointsController : ControllerBase
    {
        private readonly PointRepository _pointRepository;
        private readonly TripRepository _tripRepository;

        public PointsController(
            PointRepository pointRepository, 
            TripRepository tripRepository
            )
        {
            _pointRepository = pointRepository;
            _tripRepository = tripRepository;
        }

        [HttpGet("{id}")]
        public async Task<List<Place>> GetAllPlaces(int id)
        {
            var point = await _pointRepository.GetById(id);

            return point.Places.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> AddPoint(int tripId, Point point)
        {
            if(!(await _tripRepository.Exists(tripId))) return NotFound();

            var trip = await _tripRepository.GetById(tripId);

            if(trip.Points.Contains(point)) return BadRequest();

            var created = await CreatePoint(point);

            trip.Points.Add(point);

            return Ok(created);
        }

        private async Task<IActionResult> CreatePoint(Point point)
        {
            var created = await _pointRepository.Add(point);

            if(created == null) return BadRequest();

            return StatusCode(201, created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var point = await _pointRepository.GetById(id);

            if(point == null) return NotFound();

            var deleted = await _pointRepository.Delete(id);

            return Ok(deleted);
        }

        [HttpPut(template: "{id}")]
        public async Task<IActionResult> Update(int id, Point model)
        {
            var point = await _pointRepository.GetById(model.Id);

            if(point == null) return NotFound();

            var updated = await _pointRepository.Update(model);

            return Ok(updated);
        }

    }
}