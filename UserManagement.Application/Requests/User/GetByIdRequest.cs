using MediatR;

namespace UserManagement.Application.Requests.User;

public class GetByIdRequest : IRequest<Response>
{
    public required ulong Id { get; init; }
}