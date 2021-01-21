using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TripPlanner.API.Authentication;
using TripPlanner.API.Models;

namespace TripPlanner.API.Data
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<City> Cities { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }  
        protected override void OnModelCreating(ModelBuilder builder)  
        {  
            base.OnModelCreating(builder);  
        }  
    }
}