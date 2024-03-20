using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Interfaces;

public interface IPermissionRepository
{
    Task<bool> AssignPermissionToUserAsync(ulong userId, string permissionName);
    Task<bool> UnassignPermissionFromUserAsync(ulong userId, string permissionName);

    Task<Permission> CreatePermissionAsync(Permission permission);

    Task<IEnumerable<Permission>> GetPermissionFromUserAsync(ulong userId);
}