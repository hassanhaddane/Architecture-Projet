using GestionHotel.Apis.Data;
using GestionHotel.Apis.Domain.Customers;
using GestionHotel.Apis.Domain.Employees;
using Microsoft.EntityFrameworkCore;

namespace GestionHotel.Apis.Persistence.Repositories
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly HotelDbContext _context;

		public EmployeeRepository(HotelDbContext context)
		{
			_context = context;
		}

		public async Task<Employee> CreateEmployee(Employee employee)
		{
			_context.Entry(employee).State = EntityState.Added;
			_context.Employees.Add(employee);
			await _context.SaveChangesAsync();
			return employee;
		}

		public Task<Employee?> GetEmployeeById(int id)
		{
			return _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
		}

		public Task<List<Employee>> GetEmployeesByRole(int role)
		{
			return _context.Employees.Where(e => e.Role == role).ToListAsync();
		}

		public async void RemoveEmployee(Employee employee)
		{
			_context.Entry(employee).State = EntityState.Deleted;
			_context.Employees.Remove(employee);
			await _context.SaveChangesAsync();
		}

		public async Task<Employee> UpdateEmployee(Employee employee)
		{
			_context.Entry(employee).State = EntityState.Modified;
			_context.Employees.Update(employee);
			await _context.SaveChangesAsync();
			return employee;
		}
	}
}
