using MyBuberDinner.Api.Filters;
// using MyBuberDinner.Api.Middlewares;
using MyBuberDinner.Application;
using MyBuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
}

var app = builder.Build();

{
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    
    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}
