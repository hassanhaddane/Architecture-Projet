using GestionHotel.Apis.Data;
using GestionHotel.Apis.Domain.Bookings;
using GestionHotel.Apis.Domain.Rooms;
using Microsoft.EntityFrameworkCore;

namespace GestionHotel.Apis.Persistence.Repositories
{
	public class RoomRepository : IRoomRepository
	{
		private readonly HotelDbContext _context;

		public RoomRepository(HotelDbContext context) 
		{ 
			_context = context; 
		}

		public async Task<List<Room>> GetRooms()
		{
			return await _context.Rooms
				.Include(r => r.Bookings)
				.ToListAsync();
		}

		public Task<Room?> GetRoomById(int id)
		{
			return _context.Rooms.FirstOrDefaultAsync(r => r.Id == id);
		}

        public void UpdateRoom(Room room)
		{
			_context.Rooms.Update(room);
		}

		public void AddRoom(Room room)
		{
			_context.Rooms.Add(room);
		}

		public void RemoveRoom(Room room)
		{
			_context.Rooms.Remove(room);
		}
	}
}
