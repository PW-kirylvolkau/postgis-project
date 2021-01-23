using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using TripPlanner.Client.Helpers;
using TripPlanner.Client.Models;

namespace TripPlanner.Client.Services
{
    public interface IHttpService
    {
        Task<T> Get<T>(string uri);
        Task Post(string uri, object value);
        Task<T> Post<T>(string uri, object value);
        Task Put(string uri, object value);
        Task<T> Put<T>(string uri, object value);
        Task Delete(string uri);
        Task<T> Delete<T>(string uri);
    }
    
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageService _localStorage;
        private readonly IConfiguration _configuration;

        public HttpService(
            HttpClient httpClient,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
            _localStorage = localStorageService;
            _configuration = configuration;
        }
        
        
        public async Task<T> Get<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            return await SendRequest<T>(request);
        }

        public async Task Post(string uri, object value)
        {
            var request = CreateRequest(HttpMethod.Post, uri, value);
            await SendRequest(request);
        }

        public async Task<T> Post<T>(string uri, object value)
        {
            var request = CreateRequest(HttpMethod.Post, uri, value);
            return await SendRequest<T>(request);
        }

        public async Task Put(string uri, object value)
        {
            var request = CreateRequest(HttpMethod.Put, uri, value);
            await SendRequest(request);
        }

        public async Task<T> Put<T>(string uri, object value)
        {
            var request = CreateRequest(HttpMethod.Put, uri, value);
            return await SendRequest<T>(request);
        }

        public async Task Delete(string uri)
        {
            var request = CreateRequest(HttpMethod.Delete, uri);
            await SendRequest(request);
        }

        public async Task<T> Delete<T>(string uri)
        {
            var request = CreateRequest(HttpMethod.Delete, uri);
            return await SendRequest<T>(request);
        }

        private async Task<T> SendRequest<T>(HttpRequestMessage req)
        {
            await AddJwtHeader(req);
            
            using var response = await _httpClient.SendAsync(req);
            
            await HandleErrors(response);
            
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigationManager.NavigateTo("account/logout");
                return default;
            }

            JsonSerializerOptions options = new()
            {
                PropertyNameCaseInsensitive = true
            };
                
            options.Converters.Add(new StringConverter());
            return await response.Content.ReadFromJsonAsync<T>(options);
        }
        private async Task SendRequest(HttpRequestMessage req)
        {
            await AddJwtHeader(req);

            using var response = await _httpClient.SendAsync(req);
            
            await HandleErrors(response);
            
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigationManager.NavigateTo("account/logout");
            }
        }
        private async Task AddJwtHeader(HttpRequestMessage req)
        {
            var user = await _localStorage.GetItem<User>("user");
            if (user != null)
            {
                req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);
            }
        }

        private HttpRequestMessage CreateRequest(HttpMethod method, string uri, object value = null)
        {
            var request = new HttpRequestMessage(method, uri);
            if (value != null)
            {
                request.Content = new StringContent(
                    JsonSerializer.Serialize(value),
                    encoding: Encoding.UTF8,
                    mediaType:"application/json");
            }
            return request;
        }
        
        private async Task HandleErrors(HttpResponseMessage response)
        {
            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }
        }
    }
}