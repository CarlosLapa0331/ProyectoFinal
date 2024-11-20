using System;
using System.Collections.Generic;

namespace Proyecto_Final_Turicentro_Estructura_de_datos.Models;

public partial class TblReserva
{
    public int ReservaId { get; set; }

    public int UsuarioId { get; set; }

    public int AreaId { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public decimal CostoTotal { get; set; }

    public virtual TblArea Area { get; set; } = null!;

    public virtual ICollection<TblReservasExtra> TblReservasExtras { get; set; } = new List<TblReservasExtra>();

    public virtual TblUsuario Usuario { get; set; } = null!;
}
