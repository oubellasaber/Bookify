using Application.Abtractions.Messaging;
using Bookify.Domain.Abstraction;

namespace Application.Bookings.GetBooking
{
    public sealed class GetBookingQueryHandler : IQueryHandler<GetBookingQuery, BookingResponse>
    {
        public Task<Result<BookingResponse>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
