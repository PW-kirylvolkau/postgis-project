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
using TripMapApi;
using GeoAPILibrary;

namespace TripPlanner.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]

    public class ServicesController : ControllerBase
    {

        private readonly TripRepository _tripRepository;
        public ServicesController(TripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }
        

        [HttpGet("map-data")]
        public async Task<List<MapData>> GetMapDatas(double lat, double lng)
        {
            var allMapData = await TripMapFunctions.GetMapDataList(lat,lng);
            return allMapData;
        }
        

        [HttpGet("route/{tripId}")]
        public async Task<List<Point>> GetRoute(int tripId)
        {
            var trip = await _tripRepository.GetById(tripId);
            return trip.Points;
        }

        [HttpGet("optimized-route/{tripId}")]
        public async Task<List<Point>> GetOptimizedRoute(int tripId)
        {
            var trip = await _tripRepository.GetById(tripId);
            return trip.Points;
        }

        [HttpGet("address-to-coords")]
        public async Task<Coordinates> GetCoordinates(string address)
        {
            var coords =  await GeoDataFunctions.GetCoordsFromAddress(address);
            return coords;
        }

        [HttpGet("coords-to-address")]
        public async Task<string> GetAddress(double lat, double lng)
        {
            var address = await GeoDataFunctions.GetAddressFromCoords(lat, lng);
            return address;
        }

        [HttpGet("address-to-list")]
        public async Task<List<object>> GetAddressList(string address)
        {
            var addressList = await GeoDataFunctions.GetAddressList(address);
            return addressList;
        }
    }
}