using MediatR;

namespace AgsrTechTask.Api.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}
