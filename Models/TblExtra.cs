using System;
using System.Collections.Generic;

namespace Proyecto_Final_Turicentro_Estructura_de_datos.Models;

public partial class TblExtra
{
    public int ExtraId { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public virtual ICollection<TblReservasExtra> TblReservasExtras { get; set; } = new List<TblReservasExtra>();
}
