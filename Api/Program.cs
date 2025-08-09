using Acme.ProductManagement.Api.Startup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Service Extensions
builder.Services.ConfigureDatabases(builder.Configuration, builder.Environment);
builder.Services.ConfigureRepositories();
builder.Services.ConfigureServiceLayer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsEnvironment("Local"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(builder =>
    builder.WithOrigins("http://localhost:5173")
           .AllowAnyHeader()
           .AllowAnyMethod());

app.MapControllers();

app.Run();
