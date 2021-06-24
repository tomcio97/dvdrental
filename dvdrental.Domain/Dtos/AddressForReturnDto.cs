using System;
using System.Collections.Generic;
using System.Text;

namespace dvdrental.Domain.Dtos
{
    public class AddressForReturnDto
    {
        public short AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }
}
