using Bookify.Domain.Abstraction;
using Bookify.Domain.Apartments;
using Bookify.Domain.Events;
using Bookify.Domain.Shared;

namespace Bookify.Domain.Bookings
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
        public DateTime CreatedOnUtc { get; private set; }
        public DateTime? ConfirmedOnUtc { get; private set; }
        public DateTime? RejectedOnUtc { get; private set; }
        public DateTime? CompletedOnUtc { get; private set; }
        public DateTime? CancelledOnUtc { get; private set; }

        private Booking(
            Guid id,
            Guid apartmentId,
            Guid userId,
            DateRange duration,
            Money priceForPeriod,
            Money cleaningFee,
            Money amenitiesUpCharge,
            Money totalPrice,
            BookingStatus status,
            DateTime createdOnUtc)
            : base(id)
        {
            ApartmentId = apartmentId;
            UserId = userId;
            Duration = duration;
            PriceForPeriod = priceForPeriod;
            CleaningFee = cleaningFee;
            AmenitiesUpCharge = amenitiesUpCharge;
            TotalPrice = totalPrice;
            Status = status;
            CreatedOnUtc = createdOnUtc;
        }

        public static Booking Reserve(
            Apartment apartment,
            Guid userId,
            DateRange period,
            DateTime createdOnUtc,
            PricingService pricingService)
        {
            PricingDetails pricingDetails = pricingService.CalculatePrice(apartment, period);
            var booking = new Booking(
                Guid.NewGuid(),
                apartment.Id,
                userId,
                period,
                pricingDetails.PriceForPeriod,
                pricingDetails.CleaningFee,
                pricingDetails.AmenitiesUpCharge,
                pricingDetails.TotalPrice,
                BookingStatus.Reseverd,
                createdOnUtc);

            booking.RaiseDomainEvent(new BookingReservedDomainEvent(booking.Id));

            apartment.LastBookedOnUtc = createdOnUtc;

            return booking;
        }

        public Result Confirm(DateTime utcNow)
        {
            if (Status != BookingStatus.Reseverd)
                return Result.Failure(BookingErrors.NotFound);

            Status = BookingStatus.Confirmed;
            ConfirmedOnUtc = utcNow;

            RaiseDomainEvent(new BookingConfirmedDomainEvent(Id));

            return Result.Success();
        }

        public Result Reject(DateTime utcNow)
        {
            if (Status != BookingStatus.Reseverd)
                return Result.Failure(BookingErrors.NotFound);

            Status = BookingStatus.Rejected;
            RejectedOnUtc = utcNow;

            RaiseDomainEvent(new BookingRejectedDomainEvent(Id));

            return Result.Success();
        }

        public Result Complete(DateTime utcNow)
        {
            if (Status != BookingStatus.Confirmed)
                return Result.Failure(BookingErrors.NotConfirmed);

            Status = BookingStatus.Completed;
            CompletedOnUtc = utcNow;

            RaiseDomainEvent(new BookingCompletedDomainEvent(Id));

            return Result.Success();
        }

        public Result Cancel(DateTime utcNow)
        {
            if (Status != BookingStatus.Confirmed)
                return Result.Failure(BookingErrors.NotConfirmed);

            var currentDate = DateOnly.FromDateTime(utcNow);
            if (currentDate > Duration.Start)
                return Result.Failure(BookingErrors.AlreadyStarted);

            Status = BookingStatus.Cancelled;
            CompletedOnUtc = utcNow;

            RaiseDomainEvent(new BookingReservedDomainEvent(Id));

            return Result.Success();
        }
    }
}
