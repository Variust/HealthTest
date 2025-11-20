var builder = WebApplication.CreateBuilder(args);

// Capturar el timestamp de cuando se inició el contenedor  
var deployedAt = DateTime.UtcNow;

// Add services to the container.
builder.Services.AddHealthChecks();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Health check endpoint
app.MapHealthChecks(" /health\);

// Simple health endpoint with custom response
app.MapGet(\/health/status\, () => Results.Ok(new
{
 status = \Healthy\,
 timestamp = DateTime.UtcNow,
 deployedAt = deployedAt,
 uptime = DateTime.UtcNow - deployedAt,
 service = \HealthTest.Api\,
 version = \1.0.0\,
 environment = app.Environment.EnvironmentName
}))
.WithName(\GetHealthStatus\);

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
 public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
