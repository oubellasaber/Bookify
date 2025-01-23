using Bookify.Domain.Abstraction;
using MediatR;

namespace Application.Abtractions.Messaging
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> 
        where TQuery : IQuery<TResponse>
    {
    }
}
