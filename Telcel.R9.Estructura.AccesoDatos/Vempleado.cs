using System;
using System.Collections.Generic;

namespace Telcel.R9.Estructura.AccesoDatos;

public partial class Vempleado
{
    public int EmpleadoId { get; set; }

    public string Nombre { get; set; } = null!;

    public int PuestoId { get; set; }

    public string DescripcionPuesto { get; set; } = null!;

    public int DepartamentoId { get; set; }

    public string DescripcionDepartamento { get; set; } = null!;
}
