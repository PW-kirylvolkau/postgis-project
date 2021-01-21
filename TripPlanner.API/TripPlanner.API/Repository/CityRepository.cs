using TripPlanner.API.Models;
using TripPlanner.API.Data;

namespace TripPlanner.API.Repository
{
    public class CityRepository : AppRepository<City, ApplicationContext>
    {
        public CityRepository(ApplicationContext context):base(context) { }
    }
}