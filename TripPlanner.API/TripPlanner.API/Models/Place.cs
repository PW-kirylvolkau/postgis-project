using System.ComponentModel.DataAnnotations;

namespace TripPlanner.API.Models
{
    public enum PlaceType {Food, Shop, Sight, Accomodation}
    public class Place
    {
        [Key]
        public int Id { get; set; }

        public string name { get; set; }

        public PlaceType Type { get; set; } 
    }
}