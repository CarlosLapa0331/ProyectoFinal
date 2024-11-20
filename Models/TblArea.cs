using System;
using System.Collections.Generic;

namespace Proyecto_Final_Turicentro_Estructura_de_datos.Models;

public partial class TblArea
{
    public int AreaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Tipo { get; set; } = null!;

    public decimal PrecioHora { get; set; }

    public virtual ICollection<TblReserva> TblReservas { get; set; } = new List<TblReserva>();
}
