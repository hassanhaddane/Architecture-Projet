using Microsoft.AspNetCore.Mvc;

namespace GestionHotel.Apis.Endpoints.Booking;

public static class BookingHandler
{
    public static Task<BookingView> GetAvailableRooms(HttpContext context, [AsParameters] GetAvailableRoomsInput input)
    {
        return Task.FromResult(new BookingView());
    }

    public static Task<BookingResult> Create(HttpContext context, [FromBody]BookingInput input)
    {
        return Task.FromResult(new BookingResult());
    }
}