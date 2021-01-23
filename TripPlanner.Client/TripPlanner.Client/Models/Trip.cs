using System.Collections.Generic;

namespace TripPlanner.Client.Models
{
    public class Trip
    {
        public string Name { get; set; }
        public List<Point> Points { get; set; }
    }
}