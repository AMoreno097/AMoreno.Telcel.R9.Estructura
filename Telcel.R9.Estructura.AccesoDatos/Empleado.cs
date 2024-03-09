using System;
using System.Collections.Generic;

namespace Telcel.R9.Estructura.AccesoDatos;

public partial class Empleado
{
    public int EmpleadoId { get; set; }

    public string Nombre { get; set; } = null!;

    public int? PuestoId { get; set; }

    public int? DepartamentoId { get; set; }

    public virtual Departamento? Departamento { get; set; }

    public virtual Puesto? Puesto { get; set; }


    public string DescripcionPuesto { get; set; }
    public string DescripcionDepartamento { get; set; }
}
