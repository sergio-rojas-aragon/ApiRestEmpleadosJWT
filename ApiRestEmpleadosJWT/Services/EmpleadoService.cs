using ApiRestEmpleadosJWT.Interfaces;
using ApiRestEmpleadosJWT.Models;
using ApiRestEmpleadosJWT.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace ApiRestEmpleadosJWT.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private AppDbContext _context;

        public EmpleadoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EmpleadoDTO?> CreateAsync(EmpleadoDTO emp)
        {
            try
            {
                var empleado = await _context.Empleados.FindAsync(emp.ID);
                if (empleado != null)
                {
                    // empleado ya existe
                    return null;
                }
                else { 
                    _context.Empleados.AddAsync(emp);
                    await _context.SaveChangesAsync();
                    return emp;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var _emp = await _context.Empleados.FindAsync(id);
            if (_emp == null)
            {
                return false;
            }

            _context.Empleados.Remove(_emp);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<EmpleadoDTO>> GetAsync()
        {
            try
            {
                return await _context.Empleados.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<EmpleadoDTO?> GetbyIdAsync(int id)
        {
            try
            {
                return await _context.Empleados.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<EmpleadoDTO?> UpdateAsync(int id, EmpleadoDTO emp)
        {
            var _emp = await _context.Empleados.FindAsync(id);
            if (_emp == null)
            {
                return null;
            }

            _emp.Cargo = emp.Cargo;
            _emp.Email = emp.Email;
            _emp.fechaIngreso = emp.fechaIngreso;
            _emp.nombreCompleto = emp.nombreCompleto;

            await _context.SaveChangesAsync();

            return _emp;

        }
    }
}
