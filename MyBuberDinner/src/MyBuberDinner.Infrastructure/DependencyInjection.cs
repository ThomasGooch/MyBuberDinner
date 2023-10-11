using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBuberDinner.Application.Common.interfaces.Authentication;
using MyBuberDinner.Application.Common.Interfaces.Services;
using MyBuberDinner.Infrastructure.Authentication;
using MyBuberDinner.Infrastructure.Services;

namespace MyBuberDinner.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IJwtTokenGenerator, jwtTokenGenerator>();
        
        return services;
    }
}