using MediatR;

namespace UserManagement.Application.Requests.User;

public class GetFilteredRequest : IRequest<Response>
{
    public required string Name { get; init; }
}