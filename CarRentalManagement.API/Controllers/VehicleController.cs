using CarRentalManagement.API.Dtos;
using CarRentalManagement.Repository.Models;
using CarRentalManagement.Repository.Data;  // This includes your DbContext if it's in the Data namespace
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly AppDbContext _context;  // Use AppDbContext here, not ApplicationDbContext

    public VehiclesController(AppDbContext context)  // Constructor now expects AppDbContext
    {
        _context = context;
    }


    // POST: /Vehicles
    [HttpPost]
    public async Task<ActionResult<Vehicle>> CreateVehicle(VehicleCreateDto vehicleDto)
    {
        var vehicle = new Vehicle
        {
            Type = vehicleDto.Type,
            Make = vehicleDto.Make,
            Model = vehicleDto.Model,
            Year = vehicleDto.Year,
            VIN = vehicleDto.VIN,
            RentalRate = vehicleDto.RentalRate,
            Status = "Available" // Default status when creating a new vehicle
        };

        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetVehicle), new { id = vehicle.Id }, vehicle);
    }

    // GET: /Vehicles/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<VehicleDetailDto>> GetVehicle(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle == null)
        {
            return NotFound();
        }

        var vehicleDto = new VehicleDetailDto
        {
            Id = vehicle.Id,
            Type = vehicle.Type,
            Make = vehicle.Make,
            Model = vehicle.Model,
            Year = vehicle.Year,
            VIN = vehicle.VIN,
            Status = vehicle.Status,
            CurrentMileage = vehicle.CurrentMileage,
            RentalRate = vehicle.RentalRate
        };

        return vehicleDto;
    }

    // PUT: /Vehicles/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVehicle(int id, VehicleUpdateDto vehicleDto)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle == null)
        {
            return NotFound();
        }

        vehicle.Type = vehicleDto.Type;
        vehicle.Make = vehicleDto.Make;
        vehicle.Model = vehicleDto.Model;
        vehicle.Year = vehicleDto.Year;
        vehicle.VIN = vehicleDto.VIN;
        vehicle.Status = vehicleDto.Status;
        vehicle.CurrentMileage = vehicleDto.CurrentMileage;
        vehicle.RentalRate = vehicleDto.RentalRate;

        _context.Entry(vehicle).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVehicle(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle == null)
        {
            return NotFound(new { Message = "Vehicle not found." });
        }

        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();
        return NoContent();  // Returns a 204 No Content status code to indicate successful deletion
    }

    [HttpGet]
    public async Task<IActionResult> GetAllVehicles()
    {
        var vehicles = await _context.Vehicles.ToListAsync();
        return Ok(vehicles);
    }

}
