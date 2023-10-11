
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyBuberDinner.Application.Common.interfaces.Authentication;
using MyBuberDinner.Application.Common.Interfaces.Services;


namespace MyBuberDinner.Infrastructure.Authentication;


public class jwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSettings _options;

    public jwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> options)
    {
        _dateTimeProvider = dateTimeProvider;
        _options = options.Value;
    }

    public string GenerateToken(Guid userId, string firstName, string lastName)
    {

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret)), // key needs to be a secret and 16 char string
            SecurityAlgorithms.HmacSha256
        );

        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: _options.Issuer,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_options.ExpiryMinutes), // needs to be a datetime.offset impl
            claims: claims,
            signingCredentials: signingCredentials,
            audience: _options.Audience
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
    
}
