using Application.Abtractions.Clock;
using Application.Abtractions.Messaging;
using Bookify.Domain.Abstraction;
using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Bookify.Domain.Users;

namespace Application.Bookings.ReserveBooking
{
    internal sealed class ReserveBookingCommandHandler : ICommandHandler<ReserveBookingCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PricingService _pricingService;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ReserveBookingCommandHandler(
            IUserRepository userRepository,
            IApartmentRepository apartmentRepository,
            IBookingRepository bookingRepository,
            IUnitOfWork unitOfWork,
            PricingService pricingService,
            IDateTimeProvider dateTimeProvider)
        {
            _userRepository = userRepository;
            _apartmentRepository = apartmentRepository;
            _bookingRepository = bookingRepository;
            _unitOfWork = unitOfWork;
            _pricingService = pricingService;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result<Guid>> Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetByIdAsync(request.UserId);

            if (user == null)
            {
                return Result.Failure<Guid>(UserErrors.NotFound);
            }

            Apartment? apartment = await _apartmentRepository.GetByIdAsync(request.ApartmentId);

            if (apartment == null)
            {
                return Result.Failure<Guid>(ApartmentErrors.NotFound);
            }

            var duration = DateRange.Create(request.StartDate, request.EndDate);

            // May lead to a race condition
            if (await _bookingRepository.IsOverlappingAsync(apartment, duration))
            {
                return Result.Failure<Guid>(BookingErrors.Overlap);
            }

            Booking booking = Booking.Reserve(
                apartment, 
                user.Id, 
                duration, 
                _dateTimeProvider.UtcNow, 
                _pricingService);

            _bookingRepository.Add(booking);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return booking.Id;
        }
    }
}
