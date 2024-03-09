using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.R9.Estructura.Negocio
{
    public class Puesto
    {
        public static Dictionary<string, object> GetAll()
        {
            Modelo.Puesto puesto = new Modelo.Puesto();

            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Exepcion", "" }, { "Resultado", false }, { "Puesto", null } };
            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.AmorenoEstructuraContext context = new Telcel.R9.Estructura.AccesoDatos.AmorenoEstructuraContext())
                {

                    var registros = context.Puestos.FromSqlRaw($"MostrarPuesto").ToList();

                    if (registros.Count > 0)
                    {
                        puesto.Puestos = new List<object>();
                        foreach (var registro in registros)
                        {
                            Modelo.Puesto user = new Modelo.Puesto();
                            user.PuestoID = registro.PuestoId;
                            user.Descripcion = registro.Descripcion;

                            puesto.Puestos.Add(user);
                        }
                        diccionario["Resultado"] = true;
                        diccionario["Puesto"] = puesto;
                    }
                    else
                    {
                        diccionario["Resultado"] = false;
                        diccionario["Exepcion"] = "No se encontro informacion";
                    }
                }

            }
            catch (Exception ex)
            {
                diccionario["Exepcion"] = ex;
            }
            return diccionario;
        }
    }
}
