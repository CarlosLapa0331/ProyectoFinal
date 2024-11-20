using System;
using System.Collections.Generic;

namespace Proyecto_Final_Turicentro_Estructura_de_datos.Models;

public partial class TblReportediario
{
    public DateOnly Fecha { get; set; }

    public int? TotalVisitantes { get; set; }

    public decimal? IngresosTotales { get; set; }
}
