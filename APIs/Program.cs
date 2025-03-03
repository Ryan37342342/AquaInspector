using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using AquaInspector.Data;
using AquaInspector.Services;

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
                                        

// add database context object 
builder.Services.AddDbContext<AdminDbWorker>(options =>
    options.UseNpgsql(connectionString));
// add services 
builder.Services.AddScoped<ITemperatureService, TemperatureService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    Console.Out.Write("Creating Swagger UI...");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else{
   // app.UseHttpsRedirection();
}
// create scope and DB worker
using (var scope = app.Services.CreateScope()) {
    Console.Out.WriteLine("testing db connection ... ");
    var dbContext = scope.ServiceProvider.GetRequiredService<AdminDbWorker>();
    //while less than three 
    int attempt = 0;
    bool CanConnect = false;
    while(attempt<=3){
       
        // check the database connection
        if(!dbContext.Database.CanConnect()){
            CanConnect = true;
            break;
        } 
        Console.Out.WriteLine($"Failed to connect on attempt {attempt}/3 at {DateTime.UtcNow}");
        attempt+=1;
        Thread.Sleep(10000);
    }
    // if connection failure
    if (!CanConnect){
        throw new Exception("Failed to connect to DB..");
    }
}

app.UseAuthorization();
app.MapControllers();
app.Run();