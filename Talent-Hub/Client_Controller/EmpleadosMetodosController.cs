using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Talent_Hub.Client;
using Talent_Hub.Models;

namespace Talent_Hub.Client_Controller
{
    public class EmpleadosMetodosController : Controller
    {
        private readonly EmpleadosMetodosClient _empleadosMetodosClient;

        public EmpleadosMetodosController()
        {
            _empleadosMetodosClient = new EmpleadosMetodosClient();
        }
        
        public async Task<ActionResult> ObtenerConMetodosAsignados()
        {
            var result = await _empleadosMetodosClient.ObtenerEmpleadosConMetodosAsignados();
            System.Diagnostics.Debug.WriteLine("Contenido de result: " + result);

            try
            {
                var empleados = JsonConvert.DeserializeObject<List<Empleados_Metodos>>(result);
                ViewBag.Empleados_Metodos = empleados;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al desearialisar: {ex.Message}");
                ViewBag.Error = "Error al procesar los datos recibidos.";
            }
            return View();
        }

        public async Task<ActionResult> ObtenerConMetodosCompletados()
        {
            var result = await _empleadosMetodosClient.ObtenerEmpleadosConMetodosCompletados();
            System.Diagnostics.Debug.WriteLine("Contenido de result: " + result);

            try
            {
                var empleados = JsonConvert.DeserializeObject<List<Empleados_Metodos>>(result);
                ViewBag.Empleados_Metodos = empleados;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al desearialisar: {ex.Message}");
                ViewBag.Error = "Error al procesar los datos recibidos.";
            }
            return View();
        }
    }
}