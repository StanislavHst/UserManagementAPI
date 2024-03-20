using MediatR;
using UserManagement.Application.Requests;

namespace UserManagement.Application.Base;

public abstract class BaseHandler<T> : IRequestHandler<T, Response>
    where T : IRequest<Response>
{
    protected Response Success(object data = default)
    {
        return new Response
        {
            IsSuccess = true,
            Result = data
        };
    }

    protected Response Failed(string message = "Operation failed")
    {
        return new Response
        {
            IsSuccess = false,
            ErrorMessages = new List<string> { message }
        };
    }

    public abstract Task<Response> Handle(T request, CancellationToken cancellationToken);
}