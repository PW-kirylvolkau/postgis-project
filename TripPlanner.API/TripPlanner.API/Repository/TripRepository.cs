using TripPlanner.API.Models;
using TripPlanner.API.Data;

namespace TripPlanner.API.Repository
{
    public class TripRepository : AppRepository<Trip, ApplicationContext>
    {
        public TripRepository(ApplicationContext context):base(context) { }
    }
}