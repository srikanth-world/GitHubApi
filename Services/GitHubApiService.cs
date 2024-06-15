using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GitHubApi.Models;
using Newtonsoft.Json;

namespace GitHubApi.Services
{
    public class GitHubApiService : IGitHubApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthenticationService _authService;
        private readonly string _baseUrl;

        public GitHubApiService(HttpClient httpClient, IAuthenticationService authService, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _authService = authService;
            _baseUrl = configuration["GitHubApi:BaseUrl"];
        }

        public async Task<GitHubUser> GetUserInfoAsync()
        {
            _authService.AddAuthenticationHeader(_httpClient);
            return await GetGitHubDataAsync<GitHubUser>($"{_baseUrl}/user");
        }

        public async Task<List<GitHubRepository>> GetRepositoriesAsync(string username)
        {
            _authService.AddAuthenticationHeader(_httpClient);
            return await GetGitHubDataAsync<List<GitHubRepository>>($"{_baseUrl}/users/{username}/repos");
        }

        private async Task<T> GetGitHubDataAsync<T>(string requestUri)
        {
            var response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
    }
}