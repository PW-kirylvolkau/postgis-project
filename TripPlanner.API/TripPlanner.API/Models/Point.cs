using System.ComponentModel.DataAnnotations;

namespace TripPlanner.API.Models
{
    public class Point
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Trip Trip { get; set; }

        public double Lat { get; set; }
        
        public double Lng { get; set; }
    }
}