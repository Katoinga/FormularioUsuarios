using System;
using System.ComponentModel.DataAnnotations;


namespace FormularioUsuarios.Models
{
    public class FechaNacimientoValida : ValidationAttribute
    {
        public FechaNacimientoValida()
        {
            ErrorMessage = "La fecha de nacimiento no puede ser menor que el día de hoy.";
        }

        public override bool IsValid(object value)
        {
            if (value is DateTime fechaNacimiento)
            {
                return fechaNacimiento < DateTime.Today;
            }

            return false;
        }
    }
}
