using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TripPlanner.Client.Models;
using TripPlanner.Client.Models.Auth;

namespace TripPlanner.Client.Services
{
    public interface IAccountService
    {
        User User { get; }
        Task Initialize();
        Task Login(LoginUser user);
        Task Logout();
        Task Register(RegisterUser user);
    }
    
    public class AccountService : IAccountService
    {
        private const string UserKey = "user";
        private readonly IHttpService _httpService;
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageService _localStorageService;
        
        public User User { get; private set; }

        public AccountService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService
            ) {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<User>(UserKey);
        }

        public async Task Login(LoginUser user)
        {
            User = await _httpService.Post<User>("/api/authenticate/login", user);
            await _localStorageService.SetItem(UserKey, User);
        }

        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItem(UserKey);
            _navigationManager.NavigateTo("account/login");
        }

        public async Task Register(RegisterUser user)
        {
            await _httpService.Post("/api/authenticate/register", user);
        }
    }
}