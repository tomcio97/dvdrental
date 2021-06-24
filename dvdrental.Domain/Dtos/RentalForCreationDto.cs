using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace dvdrental.Domain.Dtos
{
    public class RentalForCreationDto
    {
        public DateTime RentalDate { get; set; }
        [Required]
        public int InventoryId { get; set; }
        public DateTime? ReturnDate { get; set; }
        [Required]
        public short StaffId { get; set; }
        public RentalForCreationDto()
        {
            RentalDate = DateTime.Now;
        }
    }
}
