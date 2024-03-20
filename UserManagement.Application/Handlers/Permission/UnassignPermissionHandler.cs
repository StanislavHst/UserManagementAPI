using UserManagement.Application.Base;
using UserManagement.Application.Requests;
using UserManagement.Application.Requests.Permission;
using UserManagement.Service.Interfaces;

namespace UserManagement.Application.Handlers.Permission;

public class UnassignPermissionHandler : BaseHandler<UnassignPermissionRequest>
{
    private readonly IPermissionService _permissionService;

    public UnassignPermissionHandler(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    public override async Task<Response> Handle(UnassignPermissionRequest request, CancellationToken cancellationToken)
    {
        var result = await _permissionService.UnassignPermissionFromUserAsync(request.UserId, request.PermissionName);
        if (result)
            return Success();

        return Failed("Failed to unassign permission");
    }
}