using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AgendW.Services.AuthenticationService;

namespace AgendW.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> LoginAsync(string email, string password);
        Task<bool> RegisterAsync(string email, string nome, string password, string confirmPassword);
    }

}
