using Bookify.Domain.Abstraction;

namespace Bookify.Domain.Events
{
    public sealed record BookingConfirmedDomainEvent(Guid BookingId) : IDomainEvent;
}
