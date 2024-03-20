using UserManagement.Domain.Entities;

namespace UserManagement.Service.Interfaces;

public interface IPermissionService
{
    Task<bool> AssignPermissionToUserAsync(ulong userId, string permissionName);
    Task<bool> UnassignPermissionFromUserAsync(ulong userId, string permissionName);
    Task<IEnumerable<Permission>> GetPermissionFromUserAsync(ulong userId);
}