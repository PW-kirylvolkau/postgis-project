using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace TripPlanner.API.Models
{
    [Table("trips", Schema = "public")]
    public class Trip : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public ICollection<City> Cities { get; set; } 
        [Required]
        public int UserId { get; set; }
    }
}