using MediatR;

namespace UserManagement.Application.Requests.User;

public class DeleteUserRequest : IRequest<Response>
{
    public required ulong Id { get; init; }
}