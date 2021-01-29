using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripPlanner.API.Models
{
    public enum PlaceType {Food, Shop, Sight, Accomodation}
    public class Place
    {
        [Key]
        public int Id { get; set; }

        public int PointId { get; set; }
        public Point Point { get; set; }

        public string Name { get; set; }

        public PlaceType Type { get; set; } 
    }
}