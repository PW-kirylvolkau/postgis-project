using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TripPlanner.API.Authentication;

namespace TripPlanner.API.Models
{
    public class City 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Point> Points { get; set; }
        
        //Im not sure if this is necessary, IDK if this has functionality apart from showing the client where he has been
        public bool Visited { get; set; }

    }
}