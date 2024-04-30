// Controllers/RentalContractController.cs
using Microsoft.AspNetCore.Mvc;
using CarRentalManagement.Repository.Interfaces;
using CarRentalManagement.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalContractController : ControllerBase
    {
        private readonly IRentalContractRepository _rentalContractRepository;

        public RentalContractController(IRentalContractRepository rentalContractRepository)
        {
            _rentalContractRepository = rentalContractRepository;
        }

        // GET: api/RentalContract
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalContract>>> GetRentalContracts()
        {
            return Ok(await _rentalContractRepository.GetAllRentalContractsAsync());
        }

        // GET: api/RentalContract/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentalContract>> GetRentalContract(int id)
        {
            var rentalContract = await _rentalContractRepository.GetRentalContractByIdAsync(id);

            if (rentalContract == null)
            {
                return NotFound();
            }

            return rentalContract;
        }

        // POST: api/RentalContract
        [HttpPost]
        public async Task<ActionResult<RentalContract>> PostRentalContract(RentalContract rentalContract)
        {
            await _rentalContractRepository.AddRentalContractAsync(rentalContract);
            return CreatedAtAction("GetRentalContract", new { id = rentalContract.Id }, rentalContract);
        }

        // PUT: api/RentalContract/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentalContract(int id, RentalContract rentalContract)
        {
            if (id != rentalContract.Id)
            {
                return BadRequest();
            }

            await _rentalContractRepository.UpdateRentalContractAsync(rentalContract);
            return NoContent();
        }

        // DELETE: api/RentalContract/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentalContract(int id)
        {
            await _rentalContractRepository.DeleteRentalContractAsync(id);
            return NoContent();
        }
    }
}
