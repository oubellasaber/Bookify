using Bookify.Domain.Abstraction;

namespace Bookify.Domain.Events
{
    public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
}
