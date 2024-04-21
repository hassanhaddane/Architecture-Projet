using GestionHotel.Apis.Domain.Rooms;

namespace GestionHotel.Apis.Persistence.Repositories
{
	public interface IRoomRepository
	{
		Task<List<Room>> GetRooms();

		Task<Room> GetRoomById(int id);

		void AddRoom(Room room);

		void UpdateRoom(Room room);

		void RemoveRoom(Room room);
	}
}
