using System;
using System.Collections.Generic;

namespace Proyecto_Final_Turicentro_Estructura_de_datos.Models;

public partial class TblReporte
{
    public int ReporteId { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public int TotalVisitantes { get; set; }

    public decimal IngresosTotales { get; set; }
}
