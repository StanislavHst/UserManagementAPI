using UserManagement.Domain.Entities;
using UserManagement.Domain.Schemas;

namespace UserManagement.Service.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<IEnumerable<User>> GetFilteredUsersByNameAsync(string name);
    Task<IEnumerable<User>> GetSortedUsersByNameAsync();
    Task<IEnumerable<User>> GetPaginatedUsersAsync(int page, int pageSize);
    Task<User> GetUserByIdAsync(ulong id);

    Task<User> CreateUserAsync(CreateUserSchema schema);

    Task<bool> UpdateUserAsync(UpdateUserSchema schema);

    Task<bool> DeleteUserAsync(ulong id);
}