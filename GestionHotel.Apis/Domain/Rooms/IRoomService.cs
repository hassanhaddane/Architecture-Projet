namespace GestionHotel.Apis.Domain.Rooms
{
	public interface IRoomService
	{
		Task<Room> GetRoomById(int id);

		Task<List<Room>> GetAvailableRooms(DateTime startDate, DateTime endDate);

		void AddRoom(Room room);

		void UpdateRoom(Room room);

		void RemoveRoom(Room room);

		void RemoveRoomById(int id);
	}
}
