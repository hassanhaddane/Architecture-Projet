using GestionHotel.Apis.Domain.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionHotel.Apis.Controllers.EmployeeManagement
{
	[ApiController]
	[Route("api/employees")]
	[Authorize]
	public class EmployeesController : ControllerBase
	{
		private readonly IEmployeeService _employeeService;

		public EmployeesController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		// GET /api/employees/{id}
		[HttpGet("{id}")]
		public async Task<ActionResult<Employee>> GetEmployeeById(int id)
		{
			var employee = await _employeeService.GetEmployeeById(id);
			if (employee == null)
			{
				return NotFound();
			}
			return Ok(employee);
		}

		// GET /api/employees/role/{role}
		[HttpGet("role/{role}")]
		public async Task<ActionResult<List<Employee>>> GetEmployeesByRole(string role)
		{
			var employees = await _employeeService.GetEmployeesByRole(role);
			return Ok(employees);
		}
	}
}
