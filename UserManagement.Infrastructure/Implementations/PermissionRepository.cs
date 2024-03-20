using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Context;
using UserManagement.Infrastructure.Interfaces;

namespace UserManagement.Infrastructure.Implementations;

public class PermissionRepository : IPermissionRepository
{
    private readonly UserManagementContext _context;

    public PermissionRepository(UserManagementContext context)
    {
        _context = context;
    }

    public async Task<bool> AssignPermissionToUserAsync(ulong userId, string permissionName)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (user == null)
            return false;

        var permission = await _context.Permissions.FirstOrDefaultAsync(x => x.Name == permissionName);
        if (permission == null)
            permission = await CreatePermissionAsync(new Permission { Name = permissionName });

        var userPermission = new UserPermission
        {
            UserId = userId,
            PermissionId = permission.Id
        };

        await _context.UserPermissions.AddAsync(userPermission);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UnassignPermissionFromUserAsync(ulong userId, string permissionName)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (user == null)
            return false;

        var permission = await _context.Permissions.FirstOrDefaultAsync(x => x.Name == permissionName);
        if (permission == null)
            return false;

        var userPermission =
            await _context.UserPermissions.FirstOrDefaultAsync(x =>
                x.UserId == userId && x.PermissionId == permission.Id);
        if (userPermission == null)
            return false;

        _context.UserPermissions.Remove(userPermission);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<Permission> CreatePermissionAsync(Permission permission)
    {
        await _context.Permissions.AddAsync(permission);
        await _context.SaveChangesAsync();
        return permission;
    }

    public async Task<IEnumerable<Permission>> GetPermissionFromUserAsync(ulong userId)
    {
        return await _context.UserPermissions
            .Where(x => x.UserId == userId)
            .Select(x => x.Permission)
            .ToListAsync();
    }
}