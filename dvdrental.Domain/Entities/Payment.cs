using System;
using System.Collections.Generic;

#nullable disable

namespace dvdrental.Entities
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public short CustomerId { get; set; }
        public short StaffId { get; set; }
        public int RentalId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Rental Rental { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
