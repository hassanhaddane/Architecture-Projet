using GestionHotel.Apis.Domain.Rooms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionHotel.Apis.Controllers.RoomManagement
{
	[ApiController]
	[Route("api/rooms")]
	[Authorize]
	public class RoomsController : ControllerBase
	{
		private readonly IRoomService _roomService;

		public RoomsController(IRoomService roomService)
		{
			_roomService = roomService;
		}

		// GET /api/rooms/available
		[HttpGet("available")]
		public async Task<ActionResult<List<Room>>> GetAvailableRooms(DateTime startDate, DateTime endDate)
		{
			var rooms = await _roomService.GetAvailableRooms(startDate, endDate);
			return Ok(rooms);
		}

		// GET /api/rooms/{id}
		[HttpGet("{id}")]
		public async Task<ActionResult<Room>> GetRoom(int id)
		{
			var room = await _roomService.GetRoomById(id);
			if (room == null)
			{
				return NotFound();
			}
			return Ok(room);
		}
	}
}
