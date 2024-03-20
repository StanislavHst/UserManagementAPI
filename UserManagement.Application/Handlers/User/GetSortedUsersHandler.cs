using UserManagement.Application.Base;
using UserManagement.Application.Requests;
using UserManagement.Application.Requests.User;
using UserManagement.Service.Interfaces;

namespace UserManagement.Application.Handlers.User;

public class GetSortedUsersHandler : BaseHandler<GetSortedUsersRequest>
{
    private readonly IUserService _userService;

    public GetSortedUsersHandler(IUserService userService)
    {
        _userService = userService;
    }

    public override async Task<Response> Handle(GetSortedUsersRequest request, CancellationToken cancellationToken)
    {
        var users = await _userService.GetSortedUsersByNameAsync();
        if (users == null)
            return Failed("Failed to get users");

        return Success(users);
    }
}