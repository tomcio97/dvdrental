using System.Linq;
using dvdrental.Domain.Interfaces.Repositories;
using dvdrental.Entities;

namespace dvdrental.Database.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(DvdrentalContext context) : base(context)
        {
        }
        
        public City GetCityByName(string cityName)
        {
            return context.Cities.FirstOrDefault(c => c.City1 == cityName);
        }
    }
}
