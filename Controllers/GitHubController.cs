using Microsoft.AspNetCore.Mvc;
using GitHubApi.Models;
using GitHubApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GitHubController : ControllerBase
    {
        private readonly IGitHubApiService _gitHubApiService;

        public GitHubController(IGitHubApiService gitHubApiService)
        {
            _gitHubApiService = gitHubApiService;
        }

        [HttpGet("user")]
        public async Task<ActionResult<GitHubUser>> GetUserInfo()
        {
            var userInfo = await _gitHubApiService.GetUserInfoAsync();
            return Ok(userInfo);
        }

        [HttpGet("repositories/{username}")]
        public async Task<ActionResult<List<GitHubRepository>>> GetRepositories(string username)
        {
            var repositories = await _gitHubApiService.GetRepositoriesAsync(username);
            return Ok(repositories);
        }
    }
}