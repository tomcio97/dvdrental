using System;
using System.Collections.Generic;

#nullable disable

namespace dvdrental.Entities
{
    public partial class Address
    {
        public Address()
        {
            Customers = new HashSet<Customer>();
            Stores = new HashSet<Store>();
            staff = new HashSet<Staff>();
        }

        public short AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string District { get; set; }
        public short CityId { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<Staff> staff { get; set; }
    }
}
