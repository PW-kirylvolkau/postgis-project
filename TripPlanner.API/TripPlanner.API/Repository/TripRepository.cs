using System.Collections.Generic;
using TripPlanner.API.Data;
using System.Threading.Tasks;
using TripPlanner.API.Controllers;
using TripPlanner.API.Models;

namespace TripPlanner.API.Repository
{
    public class TripRepository : AppRepository<Trip, ApplicationContext>
    {
        public TripRepository(ApplicationContext context) : base(context)
        {
            
        }
        public async Task<bool> Exists(int id)
        {
            var trips = await GetAll();
            return trips.Exists(t => t.Id == id);
        }

        // public async Task AddPointToTrip(int tripId, Point point)
        // {
        //     var trips = await GetAll();
        //     var trip = trips.Find(t => t.Id == tripId);
        //     if (trip.Points != null)
        //     {
        //         trip.Points.Add(point);
        //     }
        //     else
        //     {
        //         if (trip != null)
        //         {
        //             trip.Points = new List<Point>() {point};
        //         }
        //     }
        //     await Context.SaveChangesAsync();
        // }
    }
}