using System.ComponentModel.DataAnnotations;

namespace TripPlanner.Client.Models.Auth
{
    public class LoginUser
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}