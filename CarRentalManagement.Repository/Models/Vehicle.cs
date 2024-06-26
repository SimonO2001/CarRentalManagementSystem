﻿// File: Models/Vehicle.cs
namespace CarRentalManagement.Repository.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string VIN { get; set; }
        public string Status { get; set; }
        public int CurrentMileage { get; set; }
        public decimal RentalRate { get; set; }
    }
}
