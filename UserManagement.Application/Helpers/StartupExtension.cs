using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Application.Handlers;
using UserManagement.Application.Handlers.User;
using UserManagement.Service.Helpers.Startup.Startup;

namespace UserManagement.Application.Helpers;

public static class StartupExtension
{
    public static void AddApiService(this IServiceCollection services)
    {
        services.AddService();
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssemblies(typeof(CreateUserHandler).GetTypeInfo().Assembly));
    }
}