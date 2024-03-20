using UserManagement.Application.Base;
using UserManagement.Application.Requests;
using UserManagement.Application.Requests.User;
using UserManagement.Service.Interfaces;

namespace UserManagement.Application.Handlers.User;

public class GetPaginatedUsersHandler : BaseHandler<GetPaginatedUsersRequest>
{
    private readonly IUserService _userService;

    public GetPaginatedUsersHandler(IUserService userService)
    {
        _userService = userService;
    }

    public override async Task<Response> Handle(GetPaginatedUsersRequest request, CancellationToken cancellationToken)
    {
        var users = await _userService.GetPaginatedUsersAsync(request.Page, request.PageSize);

        if (users == null)
            return Failed("No users found");

        return Success(users);
    }
}