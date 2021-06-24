using System;
using System.Collections.Generic;
using System.Text;
using dvdrental.Entities;

namespace dvdrental.Domain.Interfaces.Repositories
{
    public interface ICityRepository: IBaseRepository<City>
    {
        City GetCityByName(string cityName);
    }
}
