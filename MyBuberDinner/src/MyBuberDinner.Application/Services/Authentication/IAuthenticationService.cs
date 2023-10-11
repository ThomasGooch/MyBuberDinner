using MyBuberDinner.Application.Services.Authentication;

namespace MyBuberDinner.Applications.Services.Authentication;

public interface IAuthenticationService
{
    public AuthenticationResult Login(string Email, string Password);

    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password);
}