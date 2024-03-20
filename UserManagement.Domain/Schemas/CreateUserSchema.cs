using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Schemas;

public class CreateUserSchema
{
    public required string Name { get; init; }

    public required string Email { get; init; }

    public required string Password { get; init; }

    public required RoleType Role { get; init; }
}