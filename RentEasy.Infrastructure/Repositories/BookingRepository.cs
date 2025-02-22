using Microsoft.EntityFrameworkCore;
using RentEasy.Domain.Apartments;
using RentEasy.Domain.Bookings;

namespace RentEasy.Infrastructure.Repositories;

internal sealed class BookingRepository : Repository<Booking>, IBookingRepository
{
    public BookingRepository(ApplicationDbContext context) : base(context)
    {
    }

    private static readonly BookingStatus[] _activeBookingStatuses =
    {
        BookingStatus.Reserved,
        BookingStatus.Confirmed,
        BookingStatus.Completed
    };

    public async Task<bool> IsOverlappingAsync(
        Apartment apartment, 
        DateRange duration, 
        CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<Booking>()
            .AnyAsync(
                booking =>
                    booking.ApartmentId == apartment.Id &&
                    booking.Duration.Start <= duration.End &&
                    booking.Duration.End >= duration.Start &&
                    _activeBookingStatuses.Contains(booking.Status),
                cancellationToken
            );
    }
}
