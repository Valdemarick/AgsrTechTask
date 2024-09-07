using FastEndpoints;
using MediatR;

namespace AgsrTechTask.Api.Endpoints;

internal abstract class BaseEndpoint<TRequest, TResponse> : Endpoint<TRequest, TResponse>
{
    protected readonly ISender Sender;

    protected BaseEndpoint(ISender sender)
    {
        Sender = sender;
    }
}

internal abstract class BaseEndpoint<TRequest> : Endpoint<TRequest>
{
    protected readonly ISender Sender;

    protected BaseEndpoint(ISender sender)
    {
        Sender = sender;
    }
}
