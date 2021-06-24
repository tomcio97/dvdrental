using System.ComponentModel.DataAnnotations;

namespace dvdrental.Domain.Dtos
{
    public class CustomerForCreationDto
    {
        // customer properties
        [Required]
        [MaxLength(45)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(45)]
        public string LastName { get; set; }

        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        // address properties
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string Address2 { get; set; }

        [Required]
        [MaxLength(20)]
        public string District { get; set; }
        
        [MaxLength(10)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        //City properties

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        //Country properties
        [Required]
        public int CountryId { get; set; }
    }
}
