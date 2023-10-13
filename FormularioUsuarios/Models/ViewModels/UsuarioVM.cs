using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FormularioUsuarios.Models;

namespace FormularioUsuarios.Models.ViewModels
{
    public class UsuarioVM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombres es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo Nombres no puede tener más de 50 caracteres")]
        public string Nombres { get; set; } = null!;

        [Required(ErrorMessage = "El campo Apellidos es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo Apellidos no puede tener más de 50 caracteres")]
        public string Apellidos { get; set; } = null!;

        [Required(ErrorMessage = "El campo Fecha de Nacimiento es obligatorio")]
        [Display(Name = "Fecha de Nacimiento")]
        [FechaNacimientoValida]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo Numero de Documento es obligatorio")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El campo Numero de Documento debe ser de 8 digitos")]
        public int NroDocumento { get; set; }

        [Required(ErrorMessage = "El campo Departamento es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo Departamento no puede tener más de 50 caracteres")]
        public string Departamento { get; set; } = null!;

        [Required(ErrorMessage = "El campo Provincia es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo Provincia no puede tener más de 50 caracteres")]
        public string Provincia { get; set; } = null!;

        [Required(ErrorMessage = "El campo Direccion es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo Direccion no puede tener más de 50 caracteres")]
        public string Direccion { get; set; } = null!;
        public bool? Estado { get; set; }
    }
}
