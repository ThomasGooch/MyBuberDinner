using MyBuberDinner.Domain.Entities;

namespace MyBuberDinner.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token)
{ }