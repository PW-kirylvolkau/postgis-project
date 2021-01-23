using TripPlanner.API.Data;
using TripPlanner.API.Models;

namespace TripPlanner.API.Repository
{
    public class TripRepository : AppRepository<Trip, ApplicationContext>
    {
        public TripRepository(ApplicationContext context) : base(context)
        {
            
        }
    }
}