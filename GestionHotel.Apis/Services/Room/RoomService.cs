using GestionHotel.Apis.Domain.Rooms;
using GestionHotel.Apis.Persistence.Repositories;

namespace GestionHotel.Apis.Services.Room
{
	public class RoomService : IRoomService
	{
		private readonly IRoomRepository _roomRepository;
		private readonly IBookingRepository _bookingRepository;

		public RoomService(IRoomRepository roomRepository, IBookingRepository bookingRepository)
		{
			_roomRepository = roomRepository;
			_bookingRepository = bookingRepository;
		}

		public void AddRoom(Domain.Rooms.Room room)
		{
			_roomRepository.AddRoom(room);
		}

		public void RemoveRoom(Domain.Rooms.Room room)
		{
			_roomRepository.RemoveRoom(room);
		}

		public async void RemoveRoomById(int id)
		{
			var room = await _roomRepository.GetRoomById(id);
			if (room != null)
			{
				_roomRepository.RemoveRoom(room);
			}
		}

		public void UpdateRoom(Domain.Rooms.Room room)
		{
			_roomRepository.UpdateRoom(room);
		}

        public async Task<List<Domain.Rooms.Room>> GetAvailableRooms(DateTime startDate, DateTime endDate)
        {
            // Récupérer toutes les chambres
            var rooms = await _roomRepository.GetRooms();

            // Récupérer les réservations qui chevauchent la plage de dates spécifiée
            var bookings = await _bookingRepository.GetBookingsByDateRange(startDate, endDate);

            // Créer une liste d'IDs de chambres réservées
            var roomIds = bookings.Select(b => b.Room.Id).ToList();

            // Filtrer les chambres qui n'ont pas de réservations chevauchantes
            var availableRooms = roomIds.FirstOrDefault() == 0
                ? rooms
                : rooms.Where(r => !roomIds.Contains(r.Id)).ToList();

            return availableRooms;
        }

        public async Task<Domain.Rooms.Room> GetRoomById(int id)
		{
			return await _roomRepository.GetRoomById(id);
		}
	}
}
