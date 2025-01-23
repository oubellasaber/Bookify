using Application.Abtractions.Messaging;

namespace Application.Bookings.GetBooking
{
    public sealed record GetBookingQuery(Guid bookingId) : IQuery<BookingResponse>
}
