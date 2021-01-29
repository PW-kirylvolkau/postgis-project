using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TripPlanner.API.Authentication;
using TripPlanner.API.Data;
using TripPlanner.API.Models;
using TripPlanner.API.Repository;
using GeoAPILibrary;

namespace TripPlanner.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class TripsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TripRepository _tripRepository;

        public TripsController(
            UserManager<ApplicationUser> userManager,
            TripRepository tripRepository)
        {
            _userManager = userManager;
            _tripRepository = tripRepository;
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var trip = await _tripRepository.GetById(id);
            var user = await _userManager.GetUserAsync(User);
            
            if (user.Id != trip.User.Id) return NotFound();

            return Ok(trip);
        }

        [HttpGet]
        public async Task<List<Trip>> GetAll()
        {
            var allTrips = await _tripRepository.GetAll();
            var user = await _userManager.GetUserAsync(User);
            return allTrips.FindAll(t => t.User.Id == user.Id).ToList();
        }

        [HttpGet("{id}/points")]
        public async Task<List<Point>> GetAllPoints(int id)
        {
            var trip = await _tripRepository.GetById(id);
            return trip.Points.ToList();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateTrip(Trip trip)
        {
            trip.User = await _userManager.GetUserAsync(User);
            var created = await _tripRepository.Add(trip);
            return created != null
                ? CreatedAtAction("GetById", new {id = created.Id}, created) 
                : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var trip = await _tripRepository.GetById(id);
            var user = await _userManager.GetUserAsync(User);

            if (user.Id != trip.User.Id) return NotFound();
            
            var deleted = await _tripRepository.Delete(id);
            return Ok(deleted);
        }

        [HttpPut(template: "{id}")]
        public async Task<IActionResult> Update(int id, Trip model)
        {
            var user = await _userManager.GetUserAsync(User);
            var trip = await _tripRepository.GetById(model.Id);

            if (user.Id != trip.User.Id) return NotFound();

            var updated = await _tripRepository.Update(model);
            return Ok(updated);
        }

        private async Task<bool> UserIsOwner(int tripId)
        {
            var trip = await _tripRepository.GetById(tripId);
            var user = await _userManager.GetUserAsync(User);
            return trip.User.Id == user.Id;
        }

    }
}