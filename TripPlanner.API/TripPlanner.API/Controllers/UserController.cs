using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TripPlanner.API.Authentication;
using TripPlanner.API.Data;
using TripPlanner.API.Models;

namespace TripPlanner.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(ApplicationContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("info")]
        public async Task<User> GetUserInfo()
        {
            var user = await _userManager.GetUserAsync(User);
            return new User()
            {
                Name = user.UserName,
                Email = user.Email
            };
        }

    }
}