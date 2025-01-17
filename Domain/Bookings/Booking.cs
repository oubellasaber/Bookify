using Bookify.Domain.Abstraction;
using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;

namespace Bookify.Domain.Booking
{
    public class Booking : Entity
    {
        public Guid ApartmentId { get; private set; }
        public Guid UserId { get; private set; }
        public DateRange Duration { get; private set; }
        public Money PriceForPeriod { get; private set; }
        public Money CleaningFee { get; private set; }
        public Money AmenitiesUpCharge { get; private set; }
        public Money TotalPrice { get; private set; }
        public BookingStatus Status { get; private set; }
        public DateTime CreatedOn { get; private set; }

        public static Booking Reserve(
            Guid apartmentId, 
            Guid userId, 
            DateRange duration, 
            DateTime createdOn)
        {
            // Use teh domain service here 
        }
    }
}
