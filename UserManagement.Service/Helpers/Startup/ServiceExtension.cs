using Microsoft.Extensions.DependencyInjection;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Implementations;
using UserManagement.Infrastructure.Interfaces;
using UserManagement.Service.Implementations;
using UserManagement.Service.Interfaces;

namespace UserManagement.Service.Helpers.Startup.Startup;

public static class ServiceExtension
{
    public static void AddService(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPermissionService, PermissionService>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
    }
}