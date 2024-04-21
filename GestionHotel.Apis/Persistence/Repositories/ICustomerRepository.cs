using GestionHotel.Apis.Domain.Customers;

namespace GestionHotel.Apis.Persistence.Repositories
{
	public interface ICustomerRepository
	{
		Task<Customer> CreateCustomer(Customer customer);

		Task<Customer> UpdateCustomer(Customer customer);

		void RemoveCustomer(Customer customer);

		Task<Customer> GetCustomerById(int id);
	}
}
