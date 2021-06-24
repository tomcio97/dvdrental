using System;
using System.Collections.Generic;
using System.Text;

namespace dvdrental.Domain.Dtos
{
    public class RentalForReturnDto
    {
        public int RentalId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public CustomerForReturnDto Customer { get; set; }
        public InventoryForReturnDto Inventory { get; set; }
        public StaffForReturnDto Staff { get; set; }
    }
}
