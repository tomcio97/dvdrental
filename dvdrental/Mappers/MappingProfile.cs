using AutoMapper;
using dvdrental.Domain.Dtos;
using dvdrental.Entities;

namespace dvdrental.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerForReturnDto>();
            CreateMap<Address, AddressForReturnDto>().ForMember(x => x.City, y => y.MapFrom(z => z.City.City1));
            CreateMap<CustomerForCreationDto, Customer>()
                .ForMember(x => x.Address, y => y.MapFrom(z => new Address()
                {
                    Address1 = z.Address,
                    Address2 = z.Address2,
                    District = z.District,
                    PostalCode = z.PostalCode,
                    Phone = z.Phone
                }));
            CreateMap<Rental, RentalForReturnDto>();
            CreateMap<Inventory, InventoryForReturnDto>();
            CreateMap<Film, FilmForReturnDto>();
            CreateMap<Staff, StaffForReturnDto>();
            CreateMap<RentalForCreationDto, Rental>();
        }
    }
}
