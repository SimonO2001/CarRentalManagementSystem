namespace CarRentalManagement.Repository.Models
{
    public class Insurance
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string Provider { get; set; }
        public string PolicyNumber { get; set; }
        public Vehicle Vehicle { get; set; }
        // Additional properties...
    }
}
