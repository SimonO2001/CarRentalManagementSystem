// Navigate back to the API project directory if necessary
// File: Program.cs in CarRentalManagement.API

using CarRentalManagement.Repository.Data;
using CarRentalManagement.Repository.Interfaces;
using CarRentalManagement.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IServiceRecordRepository, ServiceRecordRepository>();
builder.Services.AddScoped<IRentalContractRepository, RentalContractRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IInsuranceRepository, InsuranceRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
