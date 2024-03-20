using MediatR;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Requests.User;

public class CreateUserRequest : IRequest<Response>
{
    public required string Name { get; init; }

    public required string Email { get; init; }

    public required string Password { get; init; }

    public required RoleType Role { get; init; }
}