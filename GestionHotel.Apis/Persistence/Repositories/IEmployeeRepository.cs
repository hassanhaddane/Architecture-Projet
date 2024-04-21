using GestionHotel.Apis.Domain.Employees;

namespace GestionHotel.Apis.Persistence.Repositories
{
	public interface IEmployeeRepository
	{
		Task<Employee> GetEmployeeById(int id);

		Task<List<Employee>> GetEmployeesByRole(int role);

		Task<Employee> CreateEmployee(Employee employee);

		Task<Employee> UpdateEmployee(Employee employee);

		void RemoveEmployee(Employee employee);
	}
}
