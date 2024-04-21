namespace GestionHotel.Apis.Domain.Employees
{
	public interface IEmployeeService
	{
		Task<Employee> GetEmployeeById(int id);

		Task<List<Employee>> GetEmployeesByRole(string role);
	}
}
