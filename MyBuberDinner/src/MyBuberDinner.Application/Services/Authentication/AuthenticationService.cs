using MyBuberDinner.Application.Common.interfaces.Authentication;
using MyBuberDinner.Applications.Services.Authentication;

namespace MyBuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new(Guid.NewGuid(), "FirstName", "LastName", email, "token" );
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // check if user already exists
        
        // create user (generate unique id)
        var userId = Guid.NewGuid();
        // create the token
        var token = _jwtTokenGenerator.GenerateToken( userId, firstName, lastName);

        return new(userId, firstName, lastName, email, token );
    }
}