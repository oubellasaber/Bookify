using Bookify.Domain.Abstraction;
using MediatR;

namespace Application.Abtractions.Messaging
{
    public interface ICommand : IRequest<Result>
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
