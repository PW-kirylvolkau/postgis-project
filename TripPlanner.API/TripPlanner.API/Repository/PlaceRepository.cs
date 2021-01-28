using TripPlanner.API.Data;
using TripPlanner.API.Models;

namespace TripPlanner.API.Repository
{
    public class PlaceRepository : AppRepository<Place, ApplicationContext>
    {
        public PlaceRepository(ApplicationContext context) : base(context)
        {
            
        }
    }
}