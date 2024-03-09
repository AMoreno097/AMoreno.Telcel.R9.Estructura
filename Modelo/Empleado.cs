using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public Departamento Departamento { get; set; }
        public Puesto Puesto { get; set; }

        public List<object> Empleados { get; set; }
    }
}
