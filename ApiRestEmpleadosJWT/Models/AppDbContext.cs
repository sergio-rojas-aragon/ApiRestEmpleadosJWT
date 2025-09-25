using Microsoft.EntityFrameworkCore;

namespace ApiRestEmpleadosJWT.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EmpleadoDTO> Empleados { get; set; }

    }
}
