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

    app.UseCors(policyBuilder =>
        policyBuilder
            .SetIsOriginAllowed(origin =>
                origin.StartsWith("http://localhost") ||
                origin.StartsWith("https://localhost"))
            .AllowAnyHeader()
            .AllowAnyMethod()
            .SetPreflightMaxAge(TimeSpan.FromMinutes(10)));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
