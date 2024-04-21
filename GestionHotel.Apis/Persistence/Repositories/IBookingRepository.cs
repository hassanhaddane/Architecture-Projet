using GestionHotel.Apis.Domain.Bookings;
using GestionHotel.Apis.Domain.Customers;
using GestionHotel.Apis.Domain.Rooms;

namespace GestionHotel.Apis.Persistence.Repositories
{
	public interface IBookingRepository
	{
		Task<IEnumerable<Booking>> GetBookings();

		Task<Booking> GetBookingById(int id);

		Task<List<Booking>> GetBookingsByDateRange(DateTime startDate, DateTime endDate);
	}
}
