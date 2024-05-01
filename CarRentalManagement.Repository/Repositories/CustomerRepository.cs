using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarRentalManagement.Repository.Interfaces;
using CarRentalManagement.Repository.Dtos;
using CarRentalManagement.Repository.Models;
using CarRentalManagement.Repository.Data;

namespace CarRentalManagement.Repository.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            return await _context.Customers
                                 .Select(c => new CustomerDto 
                                 {
                                     Id = c.Id, 
                                     Name = c.Name, 
                                     Email = c.Email
                                 })
                                 .ToListAsync();
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return null;
            return new CustomerDto 
            {
                Id = customer.Id, 
                Name = customer.Name, 
                Email = customer.Email
            };
        }

        public async Task AddCustomerAsync(CustomerDto customerDto, string password)
        {
            var customer = new Customer
            {
                Name = customerDto.Name,
                Email = customerDto.Email,
                PasswordHash = HashPassword(password)  // Hash and store the password
            };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(int customerId, CustomerDto customerDto, string newPassword = null)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer != null)
            {
                customer.Name = customerDto.Name;
                customer.Email = customerDto.Email;
                if (!string.IsNullOrEmpty(newPassword))
                {
                    customer.PasswordHash = HashPassword(newPassword);  // Update with new hashed password
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}
