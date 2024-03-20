using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Interfaces;
using UserManagement.Service.Interfaces;

namespace UserManagement.Service.Implementations;

public class PermissionService : IPermissionService
{
    private readonly IPermissionRepository _permissionRepository;

    public PermissionService(IPermissionRepository permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }

    public async Task<bool> AssignPermissionToUserAsync(ulong userId, string permissionName)
    {
        return await _permissionRepository.AssignPermissionToUserAsync(userId, permissionName);
    }

    public Task<bool> UnassignPermissionFromUserAsync(ulong userId, string permissionName)
    {
        return _permissionRepository.UnassignPermissionFromUserAsync(userId, permissionName);
    }

    public Task<IEnumerable<Permission>> GetPermissionFromUserAsync(ulong userId)
    {
        return _permissionRepository.GetPermissionFromUserAsync(userId);
    }
}