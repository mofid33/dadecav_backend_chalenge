using Dadecar.Application.Interfaces.Repositories;
using Dadecar.Persistence.Repositories;
using Dadecar.Persistence.Contexts;

using Dadecar.Domain.Entities;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.Add(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{

    option.UseMySql(
        builder.Configuration["ConnectionStrings:SqlConnection"], ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:SqlConnection"])
        );
});
builder.Services.AddScoped<IFlightRepository, FlightRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});
app.Run();

