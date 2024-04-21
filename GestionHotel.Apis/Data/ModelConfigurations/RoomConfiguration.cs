using GestionHotel.Apis.Constants;
using GestionHotel.Apis.Domain.Rooms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionHotel.Apis.Data.ModelConfigurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Capacity).IsRequired();
            builder.Property(c => c.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(c => c.Status).IsRequired().HasMaxLength(50);
            builder.HasMany(c => c.Bookings).WithOne(c => c.Room);
        }
    }
}
