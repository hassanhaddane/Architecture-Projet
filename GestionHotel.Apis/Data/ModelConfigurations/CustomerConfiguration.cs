using GestionHotel.Apis.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionHotel.Apis.Data.ModelConfigurations
{
	public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
	{
        public void Configure(EntityTypeBuilder<Customer> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
			builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);
			builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
			builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(20);
			builder.HasMany(c => c.Bookings).WithOne(c => c.Customer);
        }
    }
}
