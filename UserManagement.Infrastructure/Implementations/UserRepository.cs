using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Context;
using UserManagement.Infrastructure.Interfaces;

namespace UserManagement.Infrastructure.Implementations;

public class UserRepository : IUserRepository
{
    private readonly UserManagementContext _context;

    public UserRepository(UserManagementContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }


    public async Task<IEnumerable<User>> GetFilteredUsersByNameAsync(string name)
    {
        return await _context.Users.Where(x => x.Name.Contains(name)).ToListAsync();
    }

    public async Task<IEnumerable<User>> GetSortedUsersByNameAsync()
    {
        return await _context.Users.OrderBy(x => x.Name).ToListAsync();
    }

    public async Task<IEnumerable<User>> GetPaginatedUsersAsync(int page, int pageSize)
    {
        return await _context.Users
            .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(ulong id)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Id == id);
        return user ?? new User();
    }

    public async Task<User> CreateUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteUserAsync(ulong id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (user == null)
            return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}