using ClientSiteProductApiConsuming.Models;

namespace ClientSiteProductApiConsuming.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> AuthenticateAsync(UserLogin loginModel)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5160/api/Auth/login", loginModel);
            response.EnsureSuccessStatusCode();

            var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();
            return tokenResponse?.Token;

        }
    }
}
