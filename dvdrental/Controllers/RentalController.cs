using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using dvdrental.Domain.Dtos;
using dvdrental.Domain.Interfaces.Repositories;
using dvdrental.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dvdrental.Controllers
{
    [Route("api/customer/{customerId}/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalRepository rentalRepository;
        private readonly IConfigurationProvider configurationProvider;
        private readonly IRentalService rentalService;

        public RentalController(IRentalRepository rentalRepository, IConfigurationProvider configurationProvider, IRentalService rentalService)
        {
            this.rentalRepository = rentalRepository;
            this.configurationProvider = configurationProvider;
            this.rentalService = rentalService;
        }

        // GET: api/<RentalController>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute] int customerId)
        {

            return Ok(await rentalRepository.GetRentals(customerId).ProjectTo<RentalForReturnDto>(configurationProvider).ToListAsync());
        }

        // GET api/<RentalController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RentalController>
        [HttpPost]
        public async Task<IActionResult> AddRental([FromRoute] int customerId,[FromBody] RentalForCreationDto rentalForCreation)
        {
            var createdRentalEntity = await rentalService.AddRental(customerId, rentalForCreation);

            return Created($"/api/customer/{customerId}/rental/{createdRentalEntity.RentalId}", createdRentalEntity);
        }

        // PUT api/<RentalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RentalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
