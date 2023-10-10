namespace MyBuberDinner.Application;
using Microsoft.Extensions.DependencyInjection;
using MyBuberDinner.Application.Services.Authentication;
using MyBuberDinner.Applications.Services.Authentication;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services){
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}