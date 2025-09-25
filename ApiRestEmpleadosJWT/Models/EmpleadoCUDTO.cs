namespace ApiRestEmpleadosJWT.Models
{
    public class EmpleadoCUDTO
    {
        // para crear y update autonumerico con swagger
        public string nombreCompleto { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public DateTime fechaIngreso { get; set; }
    }
}
