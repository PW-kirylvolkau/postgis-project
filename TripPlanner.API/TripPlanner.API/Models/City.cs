using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace TripPlanner.API.Models
{
    [Table("cities", Schema = "public")]
    public class City : IEntity
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string Name { get; set; }
        [Required]
        public double CoordsX { get; set; }
        [Required]
        public double CoordsY { get; set; }
        //Optional I guess
        public bool Visited { get; set; }
        public string Info { get; set; }
        //Missing to Add Places
    }
}