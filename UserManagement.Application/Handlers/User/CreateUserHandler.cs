using UserManagement.Application.Base;
using UserManagement.Application.Requests;
using UserManagement.Application.Requests.User;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Schemas;
using UserManagement.Service.Helpers.Startup;
using UserManagement.Service.Interfaces;

namespace UserManagement.Application.Handlers.User;

public class CreateUserHandler : BaseHandler<CreateUserRequest>
{
    private readonly IUserService _userService;
    private readonly IPermissionService _permissionService;

    public CreateUserHandler(IUserService userService, IPermissionService permissionService)
    {
        _userService = userService;
        _permissionService = permissionService;
    }

    public override async Task<Response> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userService.CreateUserAsync(new CreateUserSchema()
        {
            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
            Role = request.Role
        });

        if (user.IsNullOrDefault())
            return Failed("Не вдалося створити користувача");

        var isSuccessPermissionCreate = false;
        switch (request.Role)
        {
            case RoleType.Admin:
                isSuccessPermissionCreate = await _permissionService.AssignPermissionToUserAsync(user.Id, "Admin");
                break;
            case RoleType.User:
                isSuccessPermissionCreate = await _permissionService.AssignPermissionToUserAsync(user.Id, "User");
                break;
        }

        if (!isSuccessPermissionCreate)
            return Failed("Не вдалося створити права адміністратора");

        return Success();
    }
}