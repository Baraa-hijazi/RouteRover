using Microsoft.OpenApi.Models;
using RouteRover.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Directions", Version = "v1" }));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();

// Options
builder.Services.AddOptions<GoogleMapsOptions>().Bind(builder.Configuration.GetSection(GoogleMapsOptions.GoogleMaps));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();