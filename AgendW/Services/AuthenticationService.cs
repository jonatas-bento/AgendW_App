using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AgendW.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private static readonly string BaseUrl = "http://192.168.8.106:5000/api/auth/";
        private static readonly HttpClient _client = new HttpClient();
        public class LoginResponse
        {
            public bool Success { get; set; }
            public AuthenticationResponse Data { get; set; }
        }

        public class AuthenticationResponse
        {
            public string AccessToken { get; set; }
            public int ExpiresIn { get; set; } // Added ExpiresIn
            public UserTokenViewModel UserToken { get; set; }
        }

        public class UserTokenViewModel
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string Nome { get; set; }
            public string NomeFoto { get; set; }  // if it can be null, consider using nullable: string?
            public int Atribuicao { get; set; }
            public IEnumerable<ClaimViewModel> Claims { get; set; }
        }

        public class ClaimViewModel
        {
            public string Value { get; set; }
            public string Type { get; set; }
        }


        public async Task<AuthenticationResponse> LoginAsync(string email, string password)
        {
            var loginRequest = new
            {
                Email = email,
                Password = password
            };

            var json = System.Text.Json.JsonSerializer.Serialize(loginRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(BaseUrl + "entrar", content);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var authResponse = JsonConvert.DeserializeObject<LoginResponse>(responseBody);
                return authResponse.Data;
            }
            else
            {
                // Handle the error accordingly
                throw new Exception("Failed to login");
            }
        }

        public async Task<bool> RegisterAsync(string email, string nome, string password, string confirmPassword)
        {
            var registerRequest = new
            {
                Email = email,
                Nome = nome,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = System.Text.Json.JsonSerializer.Serialize(registerRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(BaseUrl + "nova-conta", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                // Handle the error accordingly
                throw new Exception("Failed to register");
            }
        }
    }
}
