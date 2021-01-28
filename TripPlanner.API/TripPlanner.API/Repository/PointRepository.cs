using TripPlanner.API.Data;
using System.Threading.Tasks;
using TripPlanner.API.Models;

namespace TripPlanner.API.Repository
{
    public class PointRepository : AppRepository<Point, ApplicationContext>
    {
        public PointRepository(ApplicationContext context) : base(context)
        {
            
        }

        public async Task<bool> Exists(int id)
        {
            var trips = await GetAll();
            return trips.Exists(t => t.Id == id);
        } 
    }
}