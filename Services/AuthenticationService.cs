using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

namespace GitHubApi.Services
{

  public class AuthenticationService : IAuthenticationService
  {
    private readonly string _personalAccessToken;
    public AuthenticationService(IConfiguration configuration)
    {
      _personalAccessToken = configuration["GitHubApi:PAT"];
    }

    public void AddAuthenticationHeader(HttpClient client)
    {
      client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _personalAccessToken);
      client.DefaultRequestHeaders.UserAgent.ParseAdd("GitHubApi");
    }

  }

}