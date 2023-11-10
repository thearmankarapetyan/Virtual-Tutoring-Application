///<summary>
/// Entry point and configuration for a web application that utilizes ASP.NET Core.
/// Configures services, including API controllers, Swagger documentation, and Entity Framework Core.
/// Defines and configures the application's endpoints, database context, and dependency injection.
/// Handles HTTP requests, enables HTTPS redirection, and sets up API documentation for development environments.
///</summary>
using Microsoft.EntityFrameworkCore;  // Entity Framework Core for database operations
using UFAR.TUTOR.Core.Services;      // Custom services for the application
using UFAR.TUTOR.Data;              // Data-related components for the application

var builder = WebApplication.CreateBuilder(args);  // Initialize a web application builder

builder.Services.AddControllers();                  // Add support for API controllers
builder.Services.AddEndpointsApiExplorer();         // Add API Explorer for endpoint documentation
builder.Services.AddSwaggerGen();                   // Add Swagger for API documentation

// Configure and add Entity Framework Core with SQL Server as the database provider
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("MainDB")));

builder.Services.AddScoped<IBotService, BotService>();  // Add a scoped service for the Bot

var app = builder.Build();  // Build the application

// If the application is in development, use Swagger and Swagger UI for API documentation
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();   // Enable HTTPS redirection for added security

app.UseAuthorization();      // Enable authorization for the application

app.MapControllers();        // Map the API controllers to the application's routes

app.Run();                   // Run the application
