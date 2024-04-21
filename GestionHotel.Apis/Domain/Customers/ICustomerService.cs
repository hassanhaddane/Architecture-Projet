namespace GestionHotel.Apis.Domain.Customers
{
	public interface ICustomerService
	{
		Task<Boolean> RemoveCustomer(Customer customer);

		Task<Customer> CreateCustomer(Customer customer);

		Task<Customer> UpdateCustomer(Customer customer);

		Task<Customer> GetCustomerById(int id);
	}
}
