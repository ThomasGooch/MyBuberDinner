using Microsoft.VisualBasic;
using MyBuberDinner.Application.Common.interfaces.Authentication;
using MyBuberDinner.Application.Common.Interfaces.Persistence;
using MyBuberDinner.Applications.Services.Authentication;
using MyBuberDinner.Domain.Entities;

namespace MyBuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private IJwtTokenGenerator _jwtTokenGenerator;
    private IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {

        // validate user does exist
        if(_userRepository.GetUser(email) is not User user) throw new Exception($"user does not exist with email: {email}"); 
        // validate user passwords match
        if(user.Password != password) throw new Exception("Invalid Password.");
        // generate a token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new(user, token );
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // validate the user doesn't exist
        
        if(_userRepository.GetUser(email) is not null) throw new Exception($"user already registered with email: {email}"); 
        
        // create user (generate unique id)
        var user = new User(){
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        _userRepository.AddUser(user);

        // create the token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new(user, token );
    }
}