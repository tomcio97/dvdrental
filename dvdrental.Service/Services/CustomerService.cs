using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using dvdrental.Domain.Dtos;
using dvdrental.Domain.Interfaces.Repositories;
using dvdrental.Domain.Interfaces.Services;
using dvdrental.Entities;
using dvdrental.Service.Exceptions;

namespace dvdrental.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper mapper;
        private readonly ICustomerRepository customerRepository;
        private readonly ICountryRepository countryRepository;
        private readonly ICityRepository cityRepository;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository, ICountryRepository countryRepository, ICityRepository cityRepository)
        {
            this.mapper = mapper;
            this.customerRepository = customerRepository;
            this.countryRepository = countryRepository;
            this.cityRepository = cityRepository;
        }
        public async Task<CustomerForReturnDto> AddCustomer(CustomerForCreationDto customerForCreation)
        {
           // check customer is already exists
           if(CustomerExists(customerForCreation.Email))
            {
                throw new BadRequestException("Customer is already exists");
            }
            
            // check country is correct
            if (!CountryExists(customerForCreation.CountryId))
            {
                throw new BadRequestException("Country id isn't correct");
            }

            var customerEntity = mapper.Map<Customer>(customerForCreation);


            var city = cityRepository.GetCityByName(customerForCreation.City);

            // check city is already exists in database or this city is the same country and add new city if false
            if (!CityExists(city, customerForCreation.CountryId))
            {
                city = await AddNewCity(customerForCreation);
            }

            customerEntity.Address.CityId = city.CityId;
            if (!await customerRepository.Add(customerEntity))
            {
                throw new Exception();
            }

            var customerForReturn = mapper.Map<CustomerForReturnDto>(customerEntity);

            return customerForReturn;
        }

        private bool CustomerExists(string email)
        {
            return !(customerRepository.GetCustomerByEmail(email) is null);
        }

        private bool CountryExists(int countryId)
        {
            return !(countryRepository.GetCountry(countryId) is null);
        }

        private bool CityExists(City city, int countryId)
        {
            return !(city is null || countryId != city.CountryId);
        }

        private async Task<City> AddNewCity(CustomerForCreationDto customerForCreation)
        {
           var city = new City()
            {
                City1 = customerForCreation.City,
                CountryId = (short)customerForCreation.CountryId
            };

            await cityRepository.Add(city);

            return city;
        }
    }
}
