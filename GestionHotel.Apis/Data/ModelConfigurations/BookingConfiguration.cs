using GestionHotel.Apis.Constants;
using GestionHotel.Apis.Domain.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionHotel.Apis.Data.ModelConfigurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.StartDate).IsRequired();
            builder.Property(b => b.EndDate).IsRequired();
            builder.Property(b => b.PaymentMethod).HasMaxLength(50);
            builder.Property(b => b.PaymentStatus).IsRequired().HasMaxLength(50);
            builder.Property(b => b.CancellationStatus).HasMaxLength(255);
            builder.Property(b => b.CancellationRefund).HasMaxLength(255);
            builder.HasOne(b => b.Room).WithMany(r => r.Bookings);
            builder.HasOne(b => b.Customer).WithMany(r => r.Bookings);
        }
    }
}
