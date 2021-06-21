using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using dvdrental.Domain.Dtos;
using dvdrental.Domain.Interfaces.Repositories;
using dvdrental.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dvdrental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;
        private readonly IConfigurationProvider configurationProvider;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper, IConfigurationProvider configurationProvider)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
            this.configurationProvider = configurationProvider;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await customerRepository.GetCustomers().ProjectTo<CustomerForReturnDto>(configurationProvider).ToListAsync());
        }

        // GET api/<CustomerController>/5
        [HttpGet("{customerId}")]
        public IActionResult Get(int customerId)
        {
            var customer = customerRepository.GetCustomer(customerId);
            if(customer is null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CustomerForReturnDto>(customer));
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerForCreation customerForCreation)
        {
            var customerEntity = mapper.Map<Customer>(customerForCreation);

            return Ok(customerEntity);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
