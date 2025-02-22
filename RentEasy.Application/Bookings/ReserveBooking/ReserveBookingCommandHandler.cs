using RentEasy.Application.Abstractions.Clock;
using RentEasy.Application.Abstractions.Messaging;
using RentEasy.Application.Exceptions;
using RentEasy.Domain.Abstractions;
using RentEasy.Domain.Apartments;
using RentEasy.Domain.Booking;
using RentEasy.Domain.Users;

namespace RentEasy.Application.Bookings.ReserveBooking;

internal sealed class ReserveBookingCommandHandler : ICommandHandler<ReserveBookingCommand, Guid>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IApartmentRepository _apartmentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly PricingService _pricingService;

    public ReserveBookingCommandHandler(
        IBookingRepository bookingRepository,
        IApartmentRepository apartmentRepository, 
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IDateTimeProvider dateTimeProvider,
        PricingService pricingService)
    {
        _bookingRepository = bookingRepository;
        _apartmentRepository = apartmentRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
        _pricingService = pricingService;
    }

    public async Task<Result<Guid>> Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
        if (user is null)
            return Result.Failure<Guid>(UserErrors.NotFound);

        var apartment = await _apartmentRepository.GetByIdAsync(request.ApartmentId, cancellationToken);
        if (apartment is null)
            return Result.Failure<Guid>(ApartmentErrors.NotFound); 

        var duration = DateRange.Create(request.StartDate, request.EndDate);
        if (await _bookingRepository.IsOverlappingAsync(apartment, duration, cancellationToken))
            return Result.Failure<Guid>(BookingErrors.Overlap);

        try
        {
            var booking = Booking.Reserve(
                apartment,
                user.Id,
                duration, 
                utcNow: _dateTimeProvider.UtcNow,
                _pricingService);

            _bookingRepository.Add(booking);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return booking.Id;
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(BookingErrors.Overlap);
        }
    }
}
