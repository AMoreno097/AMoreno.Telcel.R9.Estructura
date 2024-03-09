using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Telcel.R9.Estructura.Presentacion.Controllers
{
    public class CatalogosController : Controller
    {
        public IActionResult Catalogo()
        {
            Dictionary<string, object> ResultDepartamento = Celeste.R9.Estructura.Negocio.Departamento.GetAll();
            Dictionary<string, object> ResultPuesto = Celeste.R9.Estructura.Negocio.Puesto.GetAll();

            Modelo.Empleado empleado = new Modelo.Empleado();
            Dictionary<string, object> resultEmpleado = Celeste.R9.Estructura.Negocio.Empleado.GetAll();
            empleado = (Modelo.Empleado)resultEmpleado["Empleado"];
            bool result = (bool)ResultDepartamento["Resultado"];
            if (result == true)
            {
                empleado.Departamento = (Modelo.Departamento)ResultDepartamento["Departamento"];
                bool resultPue = (bool)ResultPuesto["Resultado"];
                if (resultPue == true)
                {
                    empleado.Puesto = (Modelo.Puesto)ResultPuesto["Puesto"];
                }
                return View(empleado);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Form(string? empleadosID)
        {
            Dictionary<string, object> ResultDepartamento = Celeste.R9.Estructura.Negocio.Departamento.GetAll();
            Dictionary<string, object> ResultPuesto = Celeste.R9.Estructura.Negocio.Puesto.GetAll();

            Modelo.Empleado empleado = new Modelo.Empleado();
            bool result = (bool)ResultDepartamento["Resultado"];
            if (result == true)
            {
                empleado.Departamento = (Modelo.Departamento)ResultDepartamento["Departamento"];
                bool resultPue = (bool)ResultPuesto["Resultado"];
                if (resultPue == true)
                {
                    empleado.Puesto = (Modelo.Puesto)ResultPuesto["Puesto"];
                }

            }
            if (empleadosID == null)
            {
                return View(empleado);
            }
            else
            {
                Dictionary<string, object> Result = Celeste.R9.Estructura.Negocio.Empleado.GetById(empleadosID);
                bool resultEmp = (bool)ResultPuesto["Resultado"];

                if (resultEmp == true)
                {
                    empleado = (Modelo.Empleado)Result["Empleados"];
                    empleado.Departamento = (Modelo.Departamento)ResultDepartamento["Departamento"];
                    empleado.Puesto = (Modelo.Puesto)ResultPuesto["Puesto"];

                    return View(empleado);
                }
                else
                {
                    string ErrorMessage = (string)Result["Exepcion"];
                    ViewBag.Message = ErrorMessage;
                    return View("Modal");
                }
            }
        }
        [HttpPost]
        public IActionResult Form(Modelo.Empleado empleado)
        {
            Dictionary<string, bool> Result = new Dictionary<string, bool>();
            if (empleado.EmpleadoID == 0)
            {
                Result = Celeste.R9.Estructura.Negocio.Empleado.Add(empleado);
                
                if (Result["Resultado"] == true)
                {

                    ViewBag.Message = "Se agrego correctamente el empleado ";
                }
                else
                {
                    ViewBag.Message = "No se puedo agregar el empleado ";
                }
            }
            else
            {
                Result = Celeste.R9.Estructura.Negocio.Empleado.Update(empleado);

                
                if (Result["Resultado"] == true)
                {
                    ViewBag.Message = "El empleado se ha actualizado correctamente";
                }
                else
                {
                    ViewBag.Message = "El empleado no se ha actualizado correctamente ";
                }
            }
            return View("Modal");
        }
        [HttpGet]
        public ActionResult Eliminar(int IdEmpleado)
        {

            bool Result = Celeste.R9.Estructura.Negocio.Empleado.Delete(IdEmpleado);
            
            if (Result == true)
            {

                ViewBag.Message = "El producto se elimino correctamente";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al momento de eliminar el producto";

            }
            return View("Modal");

        }
    }
}
