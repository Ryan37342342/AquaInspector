using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using AquaInspector.Data;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from the .env file (useful for local development)
Env.Load();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the database context using environment variables
var connectionString = $"Host={Environment.GetEnvironmentVariable("DB_HOST")};" +
                       $"Port={Environment.GetEnvironmentVariable("DB_PORT")};" +
                       $"Database={Environment.GetEnvironmentVariable("DB_NAME")};" +
                       $"Username={Environment.GetEnvironmentVariable("DB_USER")};" +
                       $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")}";

builder.Services.AddDbContext<AdminDbWorker>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// create scope and DB worker
using (var scope = app.Services.CreateScope()) {
    Console.Out.WriteLine("testing db connection ... ");
    var dbContext = scope.ServiceProvider.GetRequiredService<AdminDbWorker>();
    // check the database connection
    if(!dbContext.Database.CanConnect()){
        throw new Exception("Failure to connect to Db...");
    }
    // db connection must have been successfully 
    else
    {
         Console.Out.WriteLine("DB Connection Test Passed!!");
    }
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();