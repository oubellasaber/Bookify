using Bookify.Domain.Abstraction;
using MediatR;

namespace Application.Abtractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
