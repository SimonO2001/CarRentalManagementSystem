// IRepository/IPaymentRepository.cs
using CarRentalManagement.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalManagement.Repository.Interfaces
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetAllPaymentsAsync();
        Task<Payment> GetPaymentByIdAsync(int id);
        Task AddPaymentAsync(Payment payment);
        Task UpdatePaymentAsync(Payment payment);
        Task DeletePaymentAsync(int id);
    }
}
