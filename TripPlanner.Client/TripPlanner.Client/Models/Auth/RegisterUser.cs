using System.ComponentModel.DataAnnotations;

namespace TripPlanner.Client.Models.Auth
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}