using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using dvdrental.Domain.Dtos;

namespace dvdrental.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<CustomerForReturnDto> AddCustomer(CustomerForCreationDto customerForCreation);

    }
}
