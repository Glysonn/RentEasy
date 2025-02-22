using MediatR;
using RentEasy.Application.Abstractions.Email;
using RentEasy.Domain.Bookings;
using RentEasy.Domain.Bookings.Events;
using RentEasy.Domain.Users;

namespace RentEasy.Application.Bookings.ReserveBooking;

internal sealed class BookingReservedDomainEventHandler : INotificationHandler<BookingReservedDomainEvent>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public BookingReservedDomainEventHandler(IBookingRepository bookingRepository, IUserRepository userRepository, IEmailService emailService)
    {
        _bookingRepository = bookingRepository;
        _userRepository = userRepository;
        _emailService = emailService;
    }

    public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(notification.BookingId);
        if (booking is null)
            return;

        var user = await _userRepository.GetByIdAsync(booking.UserId);
        if (user is null)
            return;

        await _emailService.SendAsync(
            user.Email, 
            "Your booking has been reserved!",
            "You have 10 minutes to confirm this booking before it gets automatically cancelled");
    }
}
