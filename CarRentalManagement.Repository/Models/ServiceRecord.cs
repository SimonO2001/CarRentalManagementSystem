namespace CarRentalManagement.Repository.Models
{
    public class ServiceRecord
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public DateTime DateOfService { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public Vehicle Vehicle { get; set; }
        // Additional properties...
    }
}
