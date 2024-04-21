namespace GestionHotel.Apis.Domain.Bookings
{
	public interface IBookingService
	{
		Task<IEnumerable<Booking>> GetBookings();

		Task<Booking> GetBookingById(int id);
	}
}
