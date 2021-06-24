using System;
using System.Collections.Generic;
using System.Text;

namespace dvdrental.Domain.Dtos
{
    public class CustomerForReturnDto
    {
        public short CustomerId { get; set; }
        public short StoreId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool? Activebool { get; set; }
        public DateTime CreateDate { get; set; }
        public int? Active { get; set; }
        public AddressForReturnDto Address { get; set; }
    }
}
