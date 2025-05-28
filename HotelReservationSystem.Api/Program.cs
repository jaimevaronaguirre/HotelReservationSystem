using HotelReservationSystem.Api.Extensions;
using HotelReservationSystem.Api.OptionsSetup;
using HotelReservationSystem.Application;
using HotelReservationSystem.Application.Abstractions.Authentication;
using HotelReservationSystem.Infrastructure;
using HotelReservationSystem.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddTransient<IJwtProvider, JwtProvider>();

builder.Services.AddAuthorization();


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
app.SeedDataAuthentication();
app.UseCustomExceptionHandler();
app.UseCustomExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
