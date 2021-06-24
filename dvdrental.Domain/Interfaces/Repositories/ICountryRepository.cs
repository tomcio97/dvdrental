using System;
using System.Collections.Generic;
using System.Text;
using dvdrental.Entities;

namespace dvdrental.Domain.Interfaces.Repositories
{
    public interface ICountryRepository
    {
        Country GetCountry(int countryId);
    }
}
