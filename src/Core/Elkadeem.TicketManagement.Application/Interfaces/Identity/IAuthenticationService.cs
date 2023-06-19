using Elkadeem.TicketManagement.Application.Interfaces.Identity.Models;

namespace Elkadeem.TicketManagement.Application.Interfaces.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);

        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
