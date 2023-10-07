using System;
using System.Collections.Generic;

namespace ColaboradoresCRUD.Models;

public partial class Colaboradore
{
    public int ColaboradorId { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? Genero { get; set; }

    public string? EstadoCivil { get; set; }

    public DateTime? FechaNac { get; set; }

    public int? Edad { get; set; }

    public string? Dpi { get; set; }

    public string? Nit { get; set; }

    public string? AfIgss { get; set; }

    public string? AfIrtra { get; set; }

    public string? Pasaporte { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    public string? Pais { get; set; }
}
