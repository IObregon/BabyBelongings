using backend.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BabyBelongingsContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));

var app = builder.Build();

using (var scope =
       ((IApplicationBuilder) app).ApplicationServices.CreateScope())
using (var context = scope.ServiceProvider.GetService<BabyBelongingsContext>())
    context?.Database.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();