using GestionHotel.Apis.Data;
using GestionHotel.Apis.Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace GestionHotel.Apis.Persistence.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly HotelDbContext _context;

		public CustomerRepository(HotelDbContext context)
		{
			_context = context;
		}

		async Task<Customer?> ICustomerRepository.GetCustomerById(int id)
		{
			return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
		} 

		async Task<Customer> ICustomerRepository.CreateCustomer(Customer customer)
		{
			_context.Entry(customer).State = EntityState.Added;
			_context.Customers.Add(customer);
			await _context.SaveChangesAsync();
			return customer;
		}

		async Task<Customer> ICustomerRepository.UpdateCustomer(Customer customer)
		{
			_context.Entry(customer).State = EntityState.Modified;
			_context.Customers.Update(customer);
			await _context.SaveChangesAsync();
			return customer;
		}

		async void ICustomerRepository.RemoveCustomer(Customer customer)
		{
			_context.Entry(customer).State = EntityState.Deleted;
			_context.Customers.Remove(customer);
			await _context.SaveChangesAsync();
		}
	}
}
