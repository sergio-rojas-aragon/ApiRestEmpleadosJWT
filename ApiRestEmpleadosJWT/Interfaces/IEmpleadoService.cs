using ApiRestEmpleadosJWT.Models;

namespace ApiRestEmpleadosJWT.Interfaces
{
    public interface IEmpleadoService
    {
        Task<List<EmpleadoDTO>> GetAsync();
        Task<EmpleadoDTO?> GetbyIdAsync(int id);
        Task<EmpleadoDTO> CreateAsync(EmpleadoDTO emp);
        Task<EmpleadoDTO?> UpdateAsync(int id, EmpleadoDTO emp);
        Task<bool> DeleteAsync(int id);

    }
}
