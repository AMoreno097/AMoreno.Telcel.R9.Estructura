using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace Celeste.R9.Estructura.Negocio
{
    public class Empleado
    {
        public static Dictionary<string, object> GetAll()
        {
            Modelo.Empleado empleado = new Modelo.Empleado();

            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Exepcion", "" }, { "Resultado", false }, { "Empleado", null } };
            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.AmorenoEstructuraContext context = new Telcel.R9.Estructura.AccesoDatos.AmorenoEstructuraContext())
                {

                    var registros = context.Empleados.FromSqlRaw($"MostrarEmpleado").ToList();

                    if (registros.Count > 0)
                    {
                        empleado.Empleados = new List<object>();
                        foreach (var registro in registros)
                        {
                            Modelo.Empleado user = new Modelo.Empleado();
                            user.EmpleadoID = registro.EmpleadoId;
                            user.Nombre = registro.Nombre;

                            user.Departamento = new Modelo.Departamento();
                            user.Departamento.DepartamentoID = registro.DepartamentoId.Value;
                            user.Departamento.Descripcion = registro.DescripcionDepartamento;

                            user.Puesto = new Modelo.Puesto();
                            user.Puesto.PuestoID = registro.PuestoId.Value;
                            user.Puesto.Descripcion = registro.DescripcionPuesto;


                            empleado.Empleados.Add(user);
                        }
                        diccionario["Resultado"] = true;
                        diccionario["Empleado"] = empleado;
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
        public static Dictionary<string, object> GetById(string EmpleadoID)
        {
            //Modelo.Empleado empleado = new Modelo.Empleado();

            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Exepcion", "" }, { "Resultado", false }, { "Empleado", null } };
            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.AmorenoEstructuraContext context = new Telcel.R9.Estructura.AccesoDatos.AmorenoEstructuraContext())
                {

                    var registros = context.Empleados.FromSqlRaw($"MostrarEmpleadoxID {EmpleadoID}").AsEnumerable().FirstOrDefault();
                    //empleado.Empleados = new List<object>();

                    if (registros != null)
                    {
                        Modelo.Empleado User = new Modelo.Empleado();
                        User.EmpleadoID = registros.EmpleadoId;
                        User.Nombre = registros.Nombre;

                        User.Puesto = new Modelo.Puesto();
                        User.Puesto.PuestoID = registros.PuestoId.Value;
                        User.Puesto.Descripcion = registros.DescripcionPuesto;

                        User.Departamento = new Modelo.Departamento();
                        User.Departamento.DepartamentoID = registros.DepartamentoId.Value;
                        User.Departamento.Descripcion = registros.DescripcionDepartamento;

                        diccionario["Empleados"] = User;
                        diccionario["Resultado"] = true;

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
        public static Dictionary<string, bool> Add(Modelo.Empleado empleado)
        {
            Dictionary<string, bool> diccionario = new Dictionary<string, bool>();
            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.AmorenoEstructuraContext context = new Telcel.R9.Estructura.AccesoDatos.AmorenoEstructuraContext())
                {
                    int filasAfectadas = context.Database.ExecuteSqlRaw($"AgregarEmpleado '{empleado.Nombre}',{empleado.Puesto.PuestoID}, {empleado.Departamento.DepartamentoID}");
                    if (filasAfectadas > 0)
                    {
                        diccionario["Resultado"] = true;
                    }
                    else
                    {
                        diccionario["Resultado"] = false;
                    }
                }
            }
            catch (Exception ex)
            {
                
                diccionario["Resultado"] = false;
            }
            return diccionario;
        }
        public static Dictionary<string, bool> Update(Modelo.Empleado empleado)
        {
            Dictionary<string, bool> diccionario = new Dictionary<string, bool>();
            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.AmorenoEstructuraContext context = new Telcel.R9.Estructura.AccesoDatos.AmorenoEstructuraContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"UpdateProducto {empleado.EmpleadoID},'{empleado.Nombre}', {empleado.Departamento.DepartamentoID}, {empleado.Puesto.PuestoID}");
                    if (query >= 0)
                    {
                        diccionario["Resultado"] = true;
                    }
                    else
                    {
                        diccionario["Resultado"] = false;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
            }
            return diccionario;
        }
        public static bool Delete(int EmpleadoID)
        {
            bool result;
            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.AmorenoEstructuraContext context = new Telcel.R9.Estructura.AccesoDatos.AmorenoEstructuraContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"EliminarEmpleado {EmpleadoID}");
                    if (query >= 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;  
        }
    }
}