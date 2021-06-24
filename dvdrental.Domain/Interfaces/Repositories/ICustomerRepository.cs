using System.Linq;
using dvdrental.Entities;

namespace dvdrental.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        IQueryable<Customer> GetCustomers();
        Customer GetCustomer(int customerId);
        Customer GetCustomerByEmail(string email);
    }
}
