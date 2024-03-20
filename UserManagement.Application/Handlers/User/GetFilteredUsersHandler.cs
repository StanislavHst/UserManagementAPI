using UserManagement.Application.Base;
using UserManagement.Application.Requests;
using UserManagement.Application.Requests.User;
using UserManagement.Service.Interfaces;

namespace UserManagement.Application.Handlers.User;

public class GetFilteredUsersHandler : BaseHandler<GetFilteredRequest>
{
    private readonly IUserService _userService;

    public GetFilteredUsersHandler(IUserService userService)
    {
        _userService = userService;
    }

    public override async Task<Response> Handle(GetFilteredRequest request, CancellationToken cancellationToken)
    {
        var users = await _userService.GetFilteredUsersByNameAsync(request.Name);
        return Success(users);
    }
}