using ApiRestEmpleadosJWT.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRestEmpleadosJWT.Persistencia
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EmpleadoDTO> Empleados { get; set; }

    }
}
