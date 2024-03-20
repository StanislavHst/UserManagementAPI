using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Requests.Permission;

namespace UserManagement.Web.Controllers;

public class PermissionController : ControllerBase
{
    private readonly IMediator _mediator;

    public PermissionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route(nameof(AssignPermission))]
    public async Task<IActionResult> AssignPermission([FromBody] AssignPermissionRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete]
    [Route(nameof(UnassignPermission))]
    public async Task<IActionResult> UnassignPermission([FromBody] UnassignPermissionRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet]
    [Route(nameof(GetPermissions))]
    public async Task<IActionResult> GetPermissions([FromQuery] GetPermissionsRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}