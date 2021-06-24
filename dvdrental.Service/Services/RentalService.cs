using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using dvdrental.Domain.Dtos;
using dvdrental.Domain.Interfaces.Repositories;
using dvdrental.Domain.Interfaces.Services;
using dvdrental.Entities;
using dvdrental.Service.Exceptions;

namespace dvdrental.Service.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository rentalRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IStaffRepository staffRepository;
        private readonly IInventoryRepository inventoryRepository;
        private readonly IMapper mapper;

        public RentalService(IRentalRepository rentalRepository, ICustomerRepository customerRepository, IStaffRepository staffRepository,
                             IInventoryRepository inventoryRepository, IMapper mapper)
        {
            this.rentalRepository = rentalRepository;
            this.customerRepository = customerRepository;
            this.staffRepository = staffRepository;
            this.inventoryRepository = inventoryRepository;
            this.mapper = mapper;
        }
        public async Task<RentalForReturnDto> AddRental(int customerId, RentalForCreationDto rentalForCreation)
        {
          if(customerRepository.GetCustomer(customerId) is null)
            {
                throw new NotFoundException("Customer doesn't exists");
            }   

          if(inventoryRepository.GetInventory(rentalForCreation.InventoryId) is null) {
                throw new NotFoundException("Inventory doesn't exists");
            }

          if(staffRepository.GetStaff(rentalForCreation.StaffId) is null)
            {
                throw new NotFoundException("Staff doesn't exists");
            }

          if(rentalForCreation.ReturnDate is null)
            {
                var filmDurationDate = inventoryRepository.GetInventory(rentalForCreation.InventoryId).Film.RentalDuration;
                rentalForCreation.ReturnDate = rentalForCreation.RentalDate.AddDays(filmDurationDate);
            }

            var rentalEntity = mapper.Map<Rental>(rentalForCreation);

            rentalEntity.CustomerId = (short)customerId;

            await rentalRepository.Add(rentalEntity);

            return mapper.Map<RentalForReturnDto>(rentalEntity);

        }
    }
}
