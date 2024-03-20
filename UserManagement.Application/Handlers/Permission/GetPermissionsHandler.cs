using UserManagement.Application.Base;
using UserManagement.Application.Requests;
using UserManagement.Application.Requests.Permission;
using UserManagement.Service.Interfaces;

namespace UserManagement.Application.Handlers.Permission;

public class GetPermissionsHandler : BaseHandler<GetPermissionsRequest>
{
    private readonly IPermissionService _permissionService;

    public GetPermissionsHandler(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    public override async Task<Response> Handle(GetPermissionsRequest request, CancellationToken cancellationToken)
    {
        var permissions = await _permissionService.GetPermissionFromUserAsync(request.UserId);
        return Success(permissions);
    }
}