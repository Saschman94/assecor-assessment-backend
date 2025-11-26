using Assecor.Assessment.Backend.Database.Models;
using Assecor.Assessment.Backend.ModuleRegistry;
using Assecor.Assessment.Backend.SharedDomain.Application.Messaging.Handlers;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFastEndpoints();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetAllPersonsHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetPersonHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetPersonsByColorCommandHandler).Assembly);
});

builder.Services.AddModules(builder.Configuration);

var app = builder.Build();

if (!string.IsNullOrWhiteSpace(app.Configuration.GetConnectionString("DefaultConnection")))
    await DbSeeder.SeedAsync(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseFastEndpoints();

app.Run();
