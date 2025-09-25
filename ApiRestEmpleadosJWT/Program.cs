using ApiRestEmpleadosJWT.Interfaces;
using ApiRestEmpleadosJWT.Persistencia;
using ApiRestEmpleadosJWT.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Registrar Dbcontext con base de datos InMemory
builder.Services.AddDbContext<AppDbContext>(op =>
    op.UseInMemoryDatabase("dbEmpleados")
);


// se registra servicio para interfaz
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
