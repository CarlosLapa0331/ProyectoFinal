using System;
using System.Collections.Generic;

namespace Proyecto_Final_Turicentro_Estructura_de_datos.Models;

public partial class TblUsuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string? Rol { get; set; }

    public virtual ICollection<TblReserva> TblReservas { get; set; } = new List<TblReserva>();
}
