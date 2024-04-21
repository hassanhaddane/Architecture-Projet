using GestionHotel.Apis.Domain.Bookings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionHotel.Apis.Controllers.BookingManagement
{
	[ApiController]
	[Route("api/bookings")]
	public class BookingsController : ControllerBase
	{
		private readonly IBookingService _bookingService;

		public BookingsController(IBookingService bookingService)
		{
			_bookingService = bookingService;
		}

		// GET /api/bookings
		[HttpGet]
		[Authorize]
		public async Task<ActionResult<List<Booking>>> GetAllBookings()
		{
			var bookings = await _bookingService.GetBookings();
			return Ok(bookings);
		}

		// GET /api/bookings/{id}
		[HttpGet("{id}")]
		[Authorize]
		public async Task<ActionResult<Booking>> GetBookingById(int id)
		{
			var booking = await _bookingService.GetBookingById(id);
			if (booking == null)
			{
				return NotFound();
			}
			return Ok(booking);
		}
	}
}
