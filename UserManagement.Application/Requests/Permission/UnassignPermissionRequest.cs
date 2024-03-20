using MediatR;

namespace UserManagement.Application.Requests.Permission;

public class UnassignPermissionRequest : IRequest<Response>
{
    public required ulong UserId { get; init; }
    public required string PermissionName { get; init; }
}