using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Celeste.R9.Estructura.Negocio
{
    public class Departamento
    {
        public static Dictionary<string, object> GetAll()
        {
            Modelo.Departamento departamento= new Modelo.Departamento();

            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Exepcion", "" }, { "Resultado", false }, { "Departamento", null } };
            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.AmorenoEstructuraContext context = new Telcel.R9.Estructura.AccesoDatos.AmorenoEstructuraContext())
                {

                    var registros = context.Departamentos.FromSqlRaw($"MostrarDepartamentos").ToList();

                    if (registros.Count > 0)
                    {
                        departamento.Departamentos = new List<object>();
                        foreach (var registro in registros)
                        {
                            Modelo.Departamento user = new Modelo.Departamento();
                            user.DepartamentoID = registro.DepartamentoId;
                            user.Descripcion = registro.Descripcion;

                            departamento.Departamentos.Add(user);
                        }
                        diccionario["Resultado"] = true;
                        diccionario["Departamento"] = departamento;
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
