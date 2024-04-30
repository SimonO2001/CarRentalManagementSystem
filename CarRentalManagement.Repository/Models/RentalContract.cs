namespace CarRentalManagement.Repository.Models
{
    public class RentalContract
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }
        public Vehicle Vehicle { get; set; }
        public Customer Customer { get; set; }
        // Additional properties...
    }
}
