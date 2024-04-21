using GestionHotel.Apis.Domain.Bookings;
using GestionHotel.Apis.Domain.Customers;
using GestionHotel.Apis.Persistence.Repositories;

namespace GestionHotel.Apis.Services.Booking
{
    public class BookingService : IBookingService
	{
		private readonly IBookingRepository _bookingRepository;

		public BookingService(IBookingRepository bookingRepository)
		{
			_bookingRepository = bookingRepository;
		}

		public async Task<IEnumerable<Domain.Bookings.Booking>> GetBookings()
		{
			return await _bookingRepository.GetBookings();
		}

		public async Task<Domain.Bookings.Booking> GetBookingById(int id)
		{
			return await _bookingRepository.GetBookingById(id);
		}
	}
}
