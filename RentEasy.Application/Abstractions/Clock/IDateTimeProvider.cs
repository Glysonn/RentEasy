namespace RentEasy.Application.Abstractions.Clock;

internal interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
