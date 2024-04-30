// Controllers/VehicleController.cs
using Microsoft.AspNetCore.Mvc;
using CarRentalManagement.Repository.Interfaces;
using CarRentalManagement.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        // GET: api/Vehicle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        {
            return Ok(await _vehicleRepository.GetAllVehiclesAsync());
        }

        // GET: api/Vehicle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return vehicle;
        }

        // POST: api/Vehicle
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {
            await _vehicleRepository.AddVehicleAsync(vehicle);

            return CreatedAtAction(nameof(GetVehicle), new { id = vehicle.Id }, vehicle);
        }

        // PUT: api/Vehicle/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return BadRequest();
            }

            await _vehicleRepository.UpdateVehicleAsync(vehicle);

            return NoContent();
        }

        // DELETE: api/Vehicle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            await _vehicleRepository.DeleteVehicleAsync(id);

            return NoContent();
        }
    }
}
