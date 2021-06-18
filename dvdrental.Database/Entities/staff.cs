using System;
using System.Collections.Generic;

#nullable disable

namespace dvdrental.Entities
{
    public partial class staff
    {
        public staff()
        {
            Payments = new HashSet<Payment>();
            Rentals = new HashSet<Rental>();
        }

        public short StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short AddressId { get; set; }
        public string Email { get; set; }
        public short StoreId { get; set; }
        public bool? Active { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastUpdate { get; set; }
        public byte[] Picture { get; set; }

        public virtual Address Address { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
