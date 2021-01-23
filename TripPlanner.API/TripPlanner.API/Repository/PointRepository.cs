using TripPlanner.API.Data;
using TripPlanner.API.Models;

namespace TripPlanner.API.Repository
{
    public class PointRepository : AppRepository<Point, ApplicationContext>
    {
        public PointRepository(ApplicationContext context) : base(context)
        {
            
        }
    }
}