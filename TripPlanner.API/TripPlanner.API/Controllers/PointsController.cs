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
    public class PointsController : ControllerBase
    {
        private readonly PointRepository _pointRepository;

        public PointsController(PointRepository pointRepository)
        {
            _pointRepository = pointRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var point = await _pointRepository.GetById(id);

            if(point == null) return NotFound();

            return Ok(point);
        }

        [HttpGet]
        public async Task<List<Point>> GetAll()
        {
            var allPoints = await _pointRepository.GetAll();
            return allPoints.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePoint(Point point)
        {
            var created = await _pointRepository.Add(point);
            if(created == null) return BadRequest();
            return CreatedAtAction("GetById", new {id = created.Id, created});
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