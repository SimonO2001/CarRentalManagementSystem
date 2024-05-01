// ICustomerRepository.cs
using CarRentalManagement.Repository.Dtos;

public interface ICustomerRepository
{
    Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
    Task<CustomerDto> GetCustomerByIdAsync(int id);
    Task AddCustomerAsync(CustomerDto customerDto, string password);
    Task UpdateCustomerAsync(int customerId, CustomerDto customerDto, string newPassword);
    Task DeleteCustomerAsync(int id);
}
