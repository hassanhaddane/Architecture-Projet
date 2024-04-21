using GestionHotel.Apis.Domain.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionHotel.Apis.Controllers.CustomerManagement
{
	[ApiController]
	[Route("api/customers")]
	[Authorize]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerService _customerService;

		public CustomerController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		// GET /api/customers/{id}
		[HttpGet("{id}")]
		public async Task<ActionResult<Customer>> GetCustomerById(int id)
		{
			var customer = await _customerService.GetCustomerById(id);
			if (customer == null)
			{
				return NotFound();
			}
			return Ok(customer);
		}

		// POST /api/customers
		[HttpPost]
		public async Task<ActionResult<Customer>> CreateCustomer([FromBody] Customer customer)
		{
			var createdCustomer = await _customerService.CreateCustomer(customer);
			return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.Id }, createdCustomer);
		}

		// PUT /api/customers/{id}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
		{
			if (id != customer.Id)
			{
				return BadRequest();
			}
			await _customerService.UpdateCustomer(customer);
			return NoContent();
		}
	}
}
