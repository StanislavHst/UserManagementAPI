using UserManagement.Application.Base;
using UserManagement.Application.Requests;
using UserManagement.Application.Requests.User;
using UserManagement.Service.Interfaces;

namespace UserManagement.Application.Handlers.User;

public class DeleteUserHandler : BaseHandler<DeleteUserRequest>
{
    private readonly IUserService _userService;
    private readonly IPermissionService _permissionService;

    public DeleteUserHandler(IUserService userService, IPermissionService permissionService)
    {
        _userService = userService;
        _permissionService = permissionService;
    }

    public override async Task<Response> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var isSuccesDelete = await _userService.DeleteUserAsync(request.Id);
        if (!isSuccesDelete)
            return Failed();

        return Success();
    }
}