using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dvdrental.Domain.Interfaces.Repositories;
using dvdrental.Entities;

namespace dvdrental.Database.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DvdrentalContext context;

        public CountryRepository(DvdrentalContext context)
        {
            this.context = context;
        }
        public Country GetCountry(int countryId)
        {
            return context.Countries.FirstOrDefault(c => c.CountryId == countryId);
        }
    }
}
