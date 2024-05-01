using Microsoft.AspNetCore.Mvc;
using CarRentalManagement.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalManagement.Repository.Dtos;


namespace CarRentalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var customers = await _repository.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
        {
            var customer = await _repository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> PostCustomer([FromBody] CustomerDto customerDto, [FromForm] string password)
        {
            await _repository.AddCustomerAsync(customerDto, password);
            return CreatedAtAction(nameof(GetCustomer), new { id = customerDto.Id }, customerDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, [FromBody] CustomerDto customerDto, [FromForm] string newPassword)
        {
            if (id != customerDto.Id)
            {
                return BadRequest();
            }
            await _repository.UpdateCustomerAsync(id, customerDto, newPassword);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _repository.DeleteCustomerAsync(id);
            return NoContent();
        }
    }
}
