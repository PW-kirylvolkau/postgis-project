using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripPlanner.API.Data;
using TripPlanner.API.Models;
using TripPlanner.API.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace TripPlanner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly TripRepository _repository;
        private readonly ILogger<TripController> _logger;

        public TripController(TripRepository repository, ILogger<TripController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [Authorize]
         [HttpGet]
        public async Task<IEnumerable<Trip>> GetAll()
        {
            return await _repository.GetAll();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Trip trip)
        {
            var added = await _repository.Add(trip);
            if (added == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetById), new {id = added.Id}, added);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.Delete(id);
            if (deleted == null)
            {
                return BadRequest();
            }
            return StatusCode(200);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<Trip> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder([FromBody] Trip trip)
        {
            var updated = await _repository.Update(trip);
            if (updated == null)
            {
                return BadRequest();
            }
            return StatusCode(204);
        }
    }
}
