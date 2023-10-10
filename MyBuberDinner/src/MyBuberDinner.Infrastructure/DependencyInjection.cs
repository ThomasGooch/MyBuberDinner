using Microsoft.Extensions.DependencyInjection;
using MyBuberDinner.Application.Common.interfaces.Authentication;
using MyBuberDinner.Infrastructure.Authentication;

namespace MyBuberDinner.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, jwtTokenGenerator>();
        return services;
    }
}