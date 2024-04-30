namespace CarRentalManagement.Repository.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int RentalContractId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public RentalContract RentalContract { get; set; }
        // Additional properties...
    }
}
