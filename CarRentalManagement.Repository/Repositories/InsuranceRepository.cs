// Repositories/InsuranceRepository.cs
using CarRentalManagement.Repository.Data;
using CarRentalManagement.Repository.Interfaces;
using CarRentalManagement.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalManagement.Repository.Repositories
{
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly AppDbContext _context;

        public InsuranceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Insurance>> GetAllInsurancesAsync()
        {
            return await _context.Insurances.ToListAsync();
        }

        public async Task<Insurance> GetInsuranceByIdAsync(int id)
        {
            return await _context.Insurances.FindAsync(id);
        }

        public async Task AddInsuranceAsync(Insurance insurance)
        {
            _context.Insurances.Add(insurance);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateInsuranceAsync(Insurance insurance)
        {
            _context.Entry(insurance).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInsuranceAsync(int id)
        {
            var insurance = await _context.Insurances.FindAsync(id);
            if (insurance != null)
            {
                _context.Insurances.Remove(insurance);
                await _context.SaveChangesAsync();
            }
        }
    }
}
