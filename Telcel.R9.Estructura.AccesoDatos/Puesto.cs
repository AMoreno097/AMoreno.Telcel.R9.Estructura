using System;
using System.Collections.Generic;

namespace Telcel.R9.Estructura.AccesoDatos;

public partial class Puesto
{
    public int PuestoId { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
