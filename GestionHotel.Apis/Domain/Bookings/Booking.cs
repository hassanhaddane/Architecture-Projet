using GestionHotel.Apis.Domain.Customers;
using GestionHotel.Apis.Domain.Rooms;

namespace GestionHotel.Apis.Domain.Bookings
{
	public class Booking
	{
		public int Id { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int PaymentMethod { get; set; }
		public int PaymentStatus { get; set; }
		public int CancellationStatus { get; set; }
		public bool CancellationRefund { get; set; }
		public Room? Room {  get; set; }
		public Customer? Customer { get; set; }
	}
}
