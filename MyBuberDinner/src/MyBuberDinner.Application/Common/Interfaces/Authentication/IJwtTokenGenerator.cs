using MyBuberDinner.Domain.Entities;

namespace MyBuberDinner.Application.Common.interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}