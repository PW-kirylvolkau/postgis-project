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
    public class CitiesController : ControllerBase
    {
        //TODO
        // * Remove the controller.
        private readonly CityRepository _cityRepository;
        
        public CitiesController(CityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var city = await _cityRepository.GetById(id);
            if(city == null) return NotFound();

            return Ok(city);
        }

        [HttpGet]
        public async Task<List<City>> GetAll()
        {
            var allCities = await _cityRepository.GetAll();
            return allCities.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCity(City city)
        {
            var created = await _cityRepository.Add(city);

            if(created == null) return BadRequest();

            return CreatedAtAction("GetById", new {id = created.Id}, created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var city = await _cityRepository.GetById(id);

            if(city == null) return NotFound();

            var deleted = await _cityRepository.Delete(id);
            return Ok(deleted); 
        }

        [HttpPut(template: "{id}")]
        public async Task<IActionResult> Update(int id, City model)
        {
            var city = await _cityRepository.GetById(model.Id);

            if(city == null) return NotFound();

            var updated = await _cityRepository.Update(model);

            return Ok(updated);
        }
    }

}