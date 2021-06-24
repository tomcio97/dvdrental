using System.Linq;
using dvdrental.Domain.Interfaces.Repositories;
using dvdrental.Entities;
using Microsoft.EntityFrameworkCore;

namespace dvdrental.Database.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DvdrentalContext context) : base(context)
        {
        }
        public Customer GetCustomer(int customerId)
        {
            return context.Customers.Include(c => c.Address).ThenInclude(a => a.City).FirstOrDefault(x => x.CustomerId == customerId);
        }

        public Customer GetCustomerByEmail(string email)
        {
            return context.Customers.FirstOrDefault(x => x.Email == email);
        }

        public IQueryable<Customer> GetCustomers()
        {
            return context.Customers;
        }
    }
}
