using UserManagement.Application.Base;
using UserManagement.Application.Requests;
using UserManagement.Application.Requests.User;
using UserManagement.Service.Interfaces;

namespace UserManagement.Application.Handlers.User;

public class GetAllUsersHandler : BaseHandler<GetAllUsersRequest>
{
    private readonly IUserService _userService;

    public GetAllUsersHandler(IUserService userService)
    {
        _userService = userService;
    }

    public override async Task<Response> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        var users = await _userService.GetAllUsersAsync();
        return Success(users);
    }
}