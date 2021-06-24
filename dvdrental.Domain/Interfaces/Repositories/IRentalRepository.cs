using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dvdrental.Entities;

namespace dvdrental.Domain.Interfaces.Repositories
{
    public interface IRentalRepository : IBaseRepository<Rental>
    {
        IQueryable<Rental> GetRentals(int customerId);

        Rental GetRental(int customerId, int rentalId);
    }
}
