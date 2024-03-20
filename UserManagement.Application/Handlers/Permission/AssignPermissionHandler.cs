using UserManagement.Application.Base;
using UserManagement.Application.Requests;
using UserManagement.Application.Requests.Permission;
using UserManagement.Service.Interfaces;

namespace UserManagement.Application.Handlers.Permission;

public class AssignPermissionHandler : BaseHandler<AssignPermissionRequest>
{
    private readonly IPermissionService _permissionService;

    public AssignPermissionHandler(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    public override async Task<Response> Handle(AssignPermissionRequest request, CancellationToken cancellationToken)
    {
        var result = await _permissionService.AssignPermissionToUserAsync(request.UserId, request.PermissionName);
        if (result)
            return Success();

        return Failed("Operation failed");
    }
}