
using GestionHotel.Apis.Domain.Employees;

namespace GestionHotel.Apis.Services.Employee
{
	public class EmployeeService : IEmployeeService
	{
		public Task<Domain.Employees.Employee> GetEmployeeById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<Domain.Employees.Employee>> GetEmployeesByRole(string role)
		{
			throw new NotImplementedException();
		}
	}
}
