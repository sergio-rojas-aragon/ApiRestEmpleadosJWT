using ApiRestEmpleadosJWT.Interfaces;
using ApiRestEmpleadosJWT.Models;
using ApiRestEmpleadosJWT.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Registrar Dbcontext con base de datos InMemory
builder.Services.AddDbContext<AppDbContext>(op =>
    op.UseInMemoryDatabase("dbEmpleados")
);


// configuracion seguridad

var key = Encoding.UTF8.GetBytes("aKLMSLK3I4JNKNDKJFNKJN545N4J5N4J54H4G44H5JBSSDBNF3453S2223KJNF");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {

            // se dejan validaciones simples para el ejemplo
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddAuthorization();

// se registra servicio para interfaz
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();  

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
