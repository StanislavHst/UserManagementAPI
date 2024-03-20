using UserManagement.Application.Base;
using UserManagement.Application.Requests;
using UserManagement.Application.Requests.User;
using UserManagement.Domain.Schemas;
using UserManagement.Service.Interfaces;

namespace UserManagement.Application.Handlers.User;

public class UpdateUserHandler : BaseHandler<UpdateUserRequest>
{
    private readonly IUserService _userService;

    public UpdateUserHandler(IUserService userService)
    {
        _userService = userService;
    }

    public override async Task<Response> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var isSuccesUpdate = await _userService.UpdateUserAsync(new UpdateUserSchema()
        {
            Id = request.Id,
            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
            Role = request.Role
        });

        if (!isSuccesUpdate)
            return Failed("Не вдалося створити користувача");

        return Success();
    }
}