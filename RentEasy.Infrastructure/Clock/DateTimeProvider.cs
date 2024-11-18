using RentEasy.Application.Abstractions.Clock;

namespace RentEasy.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
