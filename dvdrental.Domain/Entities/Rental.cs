﻿using System;
using System.Collections.Generic;

#nullable disable

namespace dvdrental.Entities
{
    public partial class Rental
    {
        public Rental()
        {
            Payments = new HashSet<Payment>();
        }

        public int RentalId { get; set; }
        public DateTime RentalDate { get; set; }
        public int InventoryId { get; set; }
        public short CustomerId { get; set; }
        public DateTime? ReturnDate { get; set; }
        public short StaffId { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
