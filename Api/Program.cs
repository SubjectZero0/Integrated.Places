using Api;
using Api.Middleware;
using Infrastructure.Jobs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddLogging();

builder.AddAppSettings();
builder.AddGatewayModule();
builder.AddInfrastructureModule();
builder.AddApplicationModule();
builder.AddCorsPolicy();

builder.Services.AddSingleton<GlobalExceptionHandler>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/*Jobs.StartMessageBus();*/ //TODO: Find a better way to fire jobs

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandler>();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();