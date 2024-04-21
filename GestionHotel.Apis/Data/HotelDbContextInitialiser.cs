using GestionHotel.Apis.Constants;
using GestionHotel.Apis.Data.ModelConfigurations;
using GestionHotel.Apis.Domain.Bookings;
using GestionHotel.Apis.Domain.Customers;
using GestionHotel.Apis.Domain.Rooms;

namespace GestionHotel.Apis.Data
{
	public static class HotelDbContextInitialiser
	{
		public static async Task SeedAsync(HotelDbContext context)
		{
			Room Room1 = new Room { Id = 1, Capacity = 6, Price = 75, Status = Convert.ToInt32(Class.RoomStatus.Free) };
			Room Room2 = new Room { Id = 2, Capacity = 4, Price = 50, Status = Convert.ToInt32(Class.RoomStatus.Free) };
			Room Room3 = new Room { Id = 3, Capacity = 2, Price = 40, Status = Convert.ToInt32(Class.RoomStatus.Free) };
			Room Room4 = new Room { Id = 4, Capacity = 2, Price = 40, Status = Convert.ToInt32(Class.RoomStatus.Free) };
			Room Room5 = new Room { Id = 5, Capacity = 2, Price = 40, Status = Convert.ToInt32(Class.RoomStatus.Unavailable) };

			Customer Customer1 = new Customer { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890" };
			Customer Customer2 = new Customer { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", PhoneNumber = "987-654-3210" };
			Customer Customer3 = new Customer { Id = 3, FirstName = "Bob", LastName = "Johnson", Email = "bob.johnson@example.com", PhoneNumber = "456-123-7890" };

			// Seed les données de la table Rooms
			if (!context.Rooms.Any())
			{
				context.Rooms.AddRange(Room1, Room2, Room3, Room4, Room5);
				await context.SaveChangesAsync();
			}

			// Seed les données de la table Customers
			if (!context.Customers.Any())
			{
				context.Customers.AddRange(Customer1, Customer2, Customer3);
				await context.SaveChangesAsync();
			}

			// Seed les données de la table Bookings
			if (!context.Bookings.Any())
			{
				context.Bookings.AddRange(
					new Booking
					{
						Id = 1,
						Room = Room1,
						Customer = Customer1,
						StartDate = new DateTime(2023, 03, 01),
						EndDate = new DateTime(2023, 03, 05),
						PaymentMethod = Convert.ToInt32(Class.PaymentMethod.CreditCard),
						PaymentStatus = Convert.ToInt32(Class.PaymentStatus.Paid),
						CancellationStatus = Convert.ToInt32(Class.CancellationStatus.Pending),
						CancellationRefund = false
					},
					new Booking
					{
						Id = 2,
						Room = Room2,
						Customer = Customer2,
						StartDate = new DateTime(2023, 03, 10),
						EndDate = new DateTime(2023, 03, 12),
						PaymentMethod = Convert.ToInt32(Class.PaymentMethod.PayPal),
						PaymentStatus = Convert.ToInt32(Class.PaymentStatus.Pending),
						CancellationStatus = Convert.ToInt32(Class.CancellationStatus.Pending),
						CancellationRefund = false
					}
				);
				await context.SaveChangesAsync();
			}
		}
	}
}
