using TripPlanner.API.Data;
using TripPlanner.API.Models;

namespace TripPlanner.API.Repository
{
    public class CityRepository : AppRepository<City, ApplicationContext>
    {
        public CityRepository(ApplicationContext context) : base(context)
        {
            
        }
    }
}