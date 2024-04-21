using GestionHotel.Apis.Domain.Bookings;

namespace GestionHotel.Apis.Domain.Rooms
{
	public class Room
	{
		public int Id { get; set; }
		public int Capacity { get; set; }
		public decimal Price { get; set; }
		public int Status { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
