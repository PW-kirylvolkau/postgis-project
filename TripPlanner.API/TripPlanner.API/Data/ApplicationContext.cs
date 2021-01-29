using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TripPlanner.API.Authentication;
using TripPlanner.API.Models;

namespace TripPlanner.API.Data
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Place> Places { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)  
        {  
  
        }  
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Trip>()
                .HasMany<Point>()
                .WithOne(p => p.Trip)
                .OnDelete(DeleteBehavior.ClientCascade);
            
            builder.Entity<Point>()
                .HasMany<Place>()
                .WithOne(p => p.Point)
                .OnDelete(DeleteBehavior.ClientCascade);
            
            base.OnModelCreating(builder);
        }  
    }
}