using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TripPlanner.API.Authentication;

namespace TripPlanner.API.Models
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }
        public ApplicationUser User {get; set;}
        [Required]
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public List<Point> Points { get; set; }
    }
}