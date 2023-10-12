using System;
using System.Collections.Generic;

namespace FormularioUsuarios.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public int NroDocumento { get; set; }

    public string Departamento { get; set; } = null!;

    public string Provincia { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public bool? Estado { get; set; }
}
