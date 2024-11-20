using System;
using System.Collections.Generic;

namespace Proyecto_Final_Turicentro_Estructura_de_datos.Models;

public partial class TblReservasExtra
{
    public int ReservaExtraId { get; set; }

    public int ReservaId { get; set; }

    public int ExtraId { get; set; }

    public int? Cantidad { get; set; }

    public virtual TblExtra Extra { get; set; } = null!;

    public virtual TblReserva Reserva { get; set; } = null!;
}
