using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Proventech.Radio.Core.Contracts.IRepositories;
using Proventech.Radio.Infrastructure.Repositories;

// Create a new web application using the provided command-line arguments.
var builder = WebApplication.CreateBuilder(args);

// Retrieve the connection string for the database from the configuration.
var ConnectionString = builder.Configuration.GetConnectionString("Default_Con");

// Add Entity Framework Core with SQL Server to the services.
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(ConnectionString));

// Add dependency injection for the radio repository.
builder.Services.AddScoped<IRepositoryRadio, RepositoryRadio>();
builder.Services.AddScoped<IRepositoryModel , RepositoryModel>();
builder.Services.AddScoped<IUserRepo, UserRepo>();

// Configure Cross-Origin Resource Sharing (CORS) policies.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});

// Add controllers and related services to the application.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure JSON serialization options for controllers.
builder.Services.AddControllers().AddJsonOptions(option =>
{
    // Disable the default property naming policy to maintain original case.
    option.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// Build the application.
var app = builder.Build();

// If the application is in development mode, enable Swagger documentation.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirect HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Enable authorization middleware.
app.UseAuthorization();

// Map controllers and endpoints.
app.MapControllers();

// Enable CORS with the "AllowAll" policy.
app.UseCors("AllowAll");

// Start the application.
app.Run();
