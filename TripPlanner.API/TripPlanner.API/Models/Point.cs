using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripPlanner.API.Models
{
    public class Point
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int TripId { get; set; }
        public Trip Trip { get; set; }

        public double Lat { get; set; }
        
        public double Lng { get; set; }
    }
}