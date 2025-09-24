namespace ApiRestEmpleadosJWT.Models
{
    public class EmpleadoDTO
    {
        public int ID { get; set; }
        public string nombreCompleto { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public DateTime fechaIngreso { get; set; }
    }
}
