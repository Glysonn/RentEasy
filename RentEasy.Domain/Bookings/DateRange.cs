namespace RentEasy.Domain.Bookings;

public sealed record DateRange
{
    public DateOnly Start { get; init; }

    public DateOnly End { get; init; }

    public int LengthInDays => End.DayNumber - Start.DayNumber;

    private DateRange()
    {

    }

    public static DateRange Create(DateOnly start, DateOnly end)
    {
        if (start > end)
            throw new ArgumentException("End date precedes start date.");

        return new DateRange
        {
            Start = start,
            End = end
        };
    }
}
