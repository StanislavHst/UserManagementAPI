using UserManagement.Domain.Entities;
using UserManagement.Domain.Schemas;
using UserManagement.Infrastructure.Interfaces;
using UserManagement.Service.Helpers.Startup;
using UserManagement.Service.Interfaces;

namespace UserManagement.Service.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }

    public async Task<IEnumerable<User>> GetFilteredUsersByNameAsync(string name)
    {
        return await _userRepository.GetFilteredUsersByNameAsync(name);
    }

    public async Task<IEnumerable<User>> GetSortedUsersByNameAsync()
    {
        return await _userRepository.GetSortedUsersByNameAsync();
    }

    public async Task<IEnumerable<User>> GetPaginatedUsersAsync(int page, int pageSize)
    {
        return await _userRepository.GetPaginatedUsersAsync(page, pageSize);
    }

    public async Task<User> GetUserByIdAsync(ulong id)
    {
        return await _userRepository.GetUserByIdAsync(id);
    }

    public async Task<User> CreateUserAsync(CreateUserSchema schema)
    {
        var user = new User
        {
            Name = schema.Name,
            Email = schema.Email,
            Password = schema.Password,
            Role = schema.Role
        };
        user = await _userRepository.CreateUserAsync(user);
        return user ?? throw new Exception("Failed to create user");
    }

    public async Task<bool> UpdateUserAsync(UpdateUserSchema schema)
    {
        var user = new User
        {
            Id = schema.Id,
            Name = schema.Name,
            Email = schema.Email,
            Password = schema.Password,
            Role = schema.Role
        };
        user = await _userRepository.UpdateUserAsync(user);
        return !user.IsNullOrDefault();
    }

    public async Task<bool> DeleteUserAsync(ulong id)
    {
        return await _userRepository.DeleteUserAsync(id);
    }
}