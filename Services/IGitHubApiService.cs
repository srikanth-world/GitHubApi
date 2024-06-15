using System.Collections.Generic;
using System.Threading.Tasks;
using GitHubApi.Models;

namespace GitHubApi.Services
{
    public interface IGitHubApiService
    {
        Task<GitHubUser> GetUserInfoAsync();
        Task<List<GitHubRepository>> GetRepositoriesAsync(string username);
    }
}