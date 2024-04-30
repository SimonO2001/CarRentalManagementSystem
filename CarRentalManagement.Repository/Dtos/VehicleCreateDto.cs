namespace CarRentalManagement.API.Dtos
{
    public class VehicleCreateDto
    {
        public string Type { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string VIN { get; set; }
        public decimal RentalRate { get; set; }
    }
}
