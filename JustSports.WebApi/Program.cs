using JustSports.WebApi.Extensions;
using JustSports.WebApi.Helpers;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();

//### Add custom service extension
builder.Services.AddCustomAppServices(builder);

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCustomSwagger();

//app.ConfigureExceptionHandler(logger);
app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseCustomCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
