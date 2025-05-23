using HotelReservationSystem.Api.Extensions;
using HotelReservationSystem.Application;
using HotelReservationSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();    
}
app.ApplyMigration();
//app.SeedData();
app.UseCustomExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
