using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentEasy.Application.Bookings.GetBooking;
using RentEasy.Application.Bookings.ReserveBooking;

namespace RentEasy.Api.Controllers.Bookings;

[ApiController]
[Route("api/bookings")]
public class BookingsController : ControllerBase
{
    private readonly ISender _sender;

    public BookingsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooking(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetBookingQuery(id);
        
        var result = await _sender.Send(query, cancellationToken);
        
        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> ReserveBooking(ReserveBookingRequest bookingDto, CancellationToken cancellationToken)
    {
        var command = new ReserveBookingCommand(
            bookingDto.ApartmentId,
            bookingDto.UserId,
            bookingDto.StartDate,
            bookingDto.EndDate);
        
        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);
        
        return CreatedAtAction(nameof(GetBooking), new { id = result.Value }, result.Value);
    }
    
}
