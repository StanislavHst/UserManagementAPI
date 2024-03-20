using UserManagement.Application.Base;
using UserManagement.Application.Requests;
using UserManagement.Application.Requests.User;
using UserManagement.Service.Helpers.Startup;
using UserManagement.Service.Interfaces;

namespace UserManagement.Application.Handlers.User;

public class GetUserByIdHandler : BaseHandler<GetByIdRequest>
{
    private readonly IUserService _userService;

    public GetUserByIdHandler(IUserService userService)
    {
        _userService = userService;
    }

    public override async Task<Response> Handle(GetByIdRequest request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserByIdAsync(request.Id);
        if (user.IsNullOrDefault())
            return Failed("User not found");

        return Success(user);
    }
}