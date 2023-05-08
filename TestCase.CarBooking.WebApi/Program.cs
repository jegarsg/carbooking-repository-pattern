using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TestCase.CarBooking.Repository.Models;
using TestCase.CarBooking.Repository.UoW;
using TestCase.CarBooking.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RentCarContext>(x => x.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RentCar;Trusted_Connection=True;MultipleActiveResultSets=true"));
builder.Services.AddScoped<UnitOfWork, UnitOfWork>();
builder.Services.AddScoped<CarBookingService, CarBookingService>();


builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
