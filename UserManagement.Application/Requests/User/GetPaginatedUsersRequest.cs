using MediatR;

namespace UserManagement.Application.Requests.User;

public class GetPaginatedUsersRequest : IRequest<Response>
{
    public required int Page { get; init; }

    public required int PageSize { get; init; }
}