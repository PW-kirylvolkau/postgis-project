using System;

namespace TripPlanner.Client.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public DateTime Expiration { get; set; }

        public override string ToString()
        {
            return $"{UserName} - {Email} - {Token}";
        }
    }
}