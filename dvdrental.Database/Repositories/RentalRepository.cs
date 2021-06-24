using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dvdrental.Domain.Interfaces.Repositories;
using dvdrental.Entities;

namespace dvdrental.Database.Repositories
{
    public class RentalRepository : BaseRepository<Rental>, IRentalRepository
    {
        public RentalRepository(DvdrentalContext context) : base(context)
        {

        }
        public Rental GetRental(int customerId, int rentalId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Rental> GetRentals(int customerId)
        {
            return context.Rentals.Where(r => r.CustomerId == customerId);
        }
    }
}
