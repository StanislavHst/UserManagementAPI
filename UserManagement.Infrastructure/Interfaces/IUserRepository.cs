using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<IEnumerable<User>> GetFilteredUsersByNameAsync(string name);
    Task<IEnumerable<User>> GetSortedUsersByNameAsync();
    Task<IEnumerable<User>> GetPaginatedUsersAsync(int page, int pageSize);
    Task<User> GetUserByIdAsync(ulong id);

    Task<User> CreateUserAsync(User user);

    Task<User> UpdateUserAsync(User user);

    Task<bool> DeleteUserAsync(ulong id);
}