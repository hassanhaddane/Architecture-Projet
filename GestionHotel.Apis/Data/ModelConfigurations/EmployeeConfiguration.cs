using GestionHotel.Apis.Domain.Employees;
using Microsoft.EntityFrameworkCore;

namespace GestionHotel.Apis.Data.ModelConfigurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Employee> builder)
        {
			builder.HasKey(e => e.Id);
			builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
			builder.Property(e => e.LastName).IsRequired().HasMaxLength(50);
			builder.Property(e => e.Role).IsRequired().HasMaxLength(50);
		}
	}
}