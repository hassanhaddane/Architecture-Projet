using GestionHotel.Apis.Data.ModelConfigurations;
using GestionHotel.Apis.Domain.Bookings;
using GestionHotel.Apis.Domain.Customers;
using GestionHotel.Apis.Domain.Employees;
using GestionHotel.Apis.Domain.Rooms;
using Microsoft.EntityFrameworkCore;

namespace GestionHotel.Apis.Data
{
	public class HotelDbContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }

		public DbSet<Room> Rooms { get; set; }

		public DbSet<Booking> Bookings { get; set; }

		public DbSet<Employee> Employees { get; set; }

		public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
		{
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CustomerConfiguration());
			modelBuilder.ApplyConfiguration(new BookingConfiguration());
			modelBuilder.ApplyConfiguration(new RoomConfiguration());
			modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

			base.OnModelCreating(modelBuilder);
		}
	}
}
