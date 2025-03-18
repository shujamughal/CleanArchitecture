using Application.Identity;
using Application.Models.Identity;
using System.Threading.Tasks;

namespace Identity.Services
{
    public class AuthServices : IAuthService
    {
        public Task<AuthResponse> Login(AuthRequest request)
        {
            // TODO: Implement login logic
            throw new System.NotImplementedException();
        }

        public Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            // TODO: Implement registration logic
            throw new System.NotImplementedException();
        }
    }
}
