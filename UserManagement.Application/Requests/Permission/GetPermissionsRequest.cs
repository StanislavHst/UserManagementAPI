using MediatR;

namespace UserManagement.Application.Requests.Permission;

public class GetPermissionsRequest : IRequest<Response>
{
    public required ulong UserId { get; init; }
}