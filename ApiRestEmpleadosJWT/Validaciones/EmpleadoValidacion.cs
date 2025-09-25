using ApiRestEmpleadosJWT.Models;
using FluentValidation;

namespace ApiRestEmpleadosJWT.Validaciones
{
    public class EmpleadoValidacion : AbstractValidator<EmpleadoCUDTO>
    {
        public EmpleadoValidacion()
        {
            RuleFor(e => e.Email).EmailAddress().WithMessage("Tiene que ser un correo valido.");
            RuleFor(e => e.nombreCompleto).MinimumLength(1).WithMessage("El nombre tiene que tener almenos 1 caracter.");
            RuleFor(e => e.Cargo).MinimumLength(1).WithMessage("El cargo tiene que tener almenos 1 caracter.");
        }


    }
}
