using Microsoft.AspNetCore.Mvc;
using MyBuberDinner.Applications.Services.Authentication;
using MyBuberDinner.Contracts.Authentication;

namespace MyBuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{

    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService ?? throw new NullReferenceException(nameof(authenticationService));
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest registerRequest)
    {

        var authResult = _authenticationService.Register(
            FirstName: registerRequest.FirstName,
            LastName: registerRequest.LastName,
            Email: registerRequest.Email,
            Password: registerRequest.Password
        );

        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token
        );

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest loginRequest)
    {

        var authResult = _authenticationService.Login(
            Email: loginRequest.Email,
            Password: loginRequest.Password
        );

        var response = new AuthenticationResponse(
                    authResult.User.Id,
                    authResult.User.FirstName,
                    authResult.User.LastName,
                    authResult.User.Email,
                    authResult.Token
                );

        return Ok(response);
    }

}