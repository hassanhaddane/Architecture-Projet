using GestionHotel.Apis.Domain.Customers;
using GestionHotel.Apis.Persistence.Repositories;

namespace GestionHotel.Apis.Services.Customer
{
	public class CustomerService : ICustomerService
	{

		private readonly ICustomerRepository _customerRepository;

		public CustomerService(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public async Task<Domain.Customers.Customer> CreateCustomer(Domain.Customers.Customer customer)
		{
			return await _customerRepository.CreateCustomer(customer);
		}

		public async Task<Domain.Customers.Customer> GetCustomerById(int id)
		{
			return await _customerRepository.GetCustomerById(id);
		}

		public async Task<Domain.Customers.Customer> UpdateCustomer(Domain.Customers.Customer customer)
		{
			return await _customerRepository.UpdateCustomer(customer);
		}

		public Task<bool> RemoveCustomer(Domain.Customers.Customer customer)
		{
			try
			{
				_customerRepository.RemoveCustomer(customer);
				return Task.FromResult(true);
			}
			catch (Exception)
			{
				return Task.FromResult(true);
			}
		}
	}
}
