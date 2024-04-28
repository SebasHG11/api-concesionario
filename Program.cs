using System.Configuration;
using apiconcesionario;
using apiconcesionario.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApiContext>(options =>
	options.UseMySQL(builder.Configuration.GetConnectionString("cadena")));
//builder.Services.AddSqlServer<ApiContext>(builder.Configuration.GetConnectionString("cadena"));


//inyeccion de dependencias
builder.Services.AddScoped<IAutoService, AutoService>();
builder.Services.AddScoped<IMarcaService, MarcaService>();


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
