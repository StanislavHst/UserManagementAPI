using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mysqlx.Crud;
using UserManagement.Application.Requests;
using UserManagement.Application.Requests.User;

namespace UserManagement.Web.Controllers;

public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route(nameof(Create))]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpPut]
    [Route(nameof(Update))]
    public async Task<IActionResult> Update([FromBody] UpdateUserRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete]
    [Route(nameof(Delete))]
    public async Task<IActionResult> Delete([FromBody] DeleteUserRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpGet]
    [Route(nameof(GetAll))]
    public async Task<IActionResult> GetAll([FromQuery] GetAllUsersRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpGet]
    [Route(nameof(GetFilteredByName))]
    public async Task<IActionResult> GetFilteredByName([FromQuery] GetFilteredRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpGet]
    [Route(nameof(GetById))]
    public async Task<IActionResult> GetById([FromQuery] GetByIdRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpGet]
    [Route(nameof(GetSortedUsers))]
    public async Task<IActionResult> GetSortedUsers([FromQuery] GetSortedUsersRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpGet]
    [Route(nameof(GetPaginatedUsers))]
    public async Task<IActionResult> GetPaginatedUsers([FromQuery] GetPaginatedUsersRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}