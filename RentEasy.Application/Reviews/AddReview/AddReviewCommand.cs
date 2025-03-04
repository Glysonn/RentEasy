using RentEasy.Application.Abstractions.Messaging;

namespace RentEasy.Application.Reviews.AddReview;

public sealed record AddReviewCommand(
    Guid BookingId,
    int Rating,
    string Comment) : ICommand;
