using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Schemas;

public class UpdateUserSchema
{
    public required ulong Id { get; init; }

    public required string Name { get; init; }

    public required string Email { get; init; }

    public required string Password { get; init; }

    public required RoleType Role { get; init; }
}