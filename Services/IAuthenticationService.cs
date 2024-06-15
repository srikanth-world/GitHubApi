namespace GitHubApi.Services
{
    public interface IAuthenticationService
    {
        void AddAuthenticationHeader(HttpClient client);
    }
}