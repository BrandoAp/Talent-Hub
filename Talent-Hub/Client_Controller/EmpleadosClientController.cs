using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Talent_Hub.Client;
using Talent_Hub.Models;
using Talent_Hub.Service;

namespace Talent_Hub.Client_Controller
{
    public class EmpleadosClientController : Controller
    {
        private readonly EmpleadosClient _empleadosClient;

        public EmpleadosClientController()
        {
            _empleadosClient = new EmpleadosClient();
        }
        public ActionResult AddEmpleado()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddEmpleado(Empleado empleado)
        {
            if (empleado == null || string.IsNullOrEmpty(empleado.Nombre_empleado) || string.IsNullOrEmpty(empleado.Email_empleado)
                || string.IsNullOrEmpty(empleado.Posicion_actual) || string.IsNullOrEmpty(empleado.Habilidades))
            {
                ViewBag.Message = "Ingrese todos los datos solicitados";
                return View();
            }
            var result = await _empleadosClient.AddEmpleado(empleado);
            ViewBag.Message = "Empleado Agreado Correctamente";
            ViewBag.Empleados = result;
            return View();
        }

        [HttpGet]      
        public async Task<ActionResult> listarEmpleados()
        {
            var result = await _empleadosClient.listarEmpleados();
            System.Diagnostics.Debug.WriteLine("Contenido de result: " + result);

            try
            {
                var empleados = JsonConvert.DeserializeObject<List<Empleado>>(result);
                ViewBag.Empleados = empleados;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al desearialisar: {ex.Message}");
                ViewBag.Error = "Error al procesar los datos recibidos.";
            }
            return View();
        }

        public async Task<ActionResult> BuscarPorNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                ViewBag.Message = "Por favor ingrese el nombre del empleado";
                return View();
            }
            var result = await _empleadosClient.BuscarPorNombre(nombre);
            var empleado = JsonConvert.DeserializeObject<List<Empleado>>(result);
            ViewBag.Empleados = empleado;
            return View();
        }

        public ActionResult UpdateEmpleado()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UpdateEmpleado(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                var result = await _empleadosClient.UpdateEmpleado(empleado);
                ViewBag.Message = result;
                return View();
            }
            return View();
        }

        public ActionResult AsignarMetodo()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AsignarMetodo(int idEmpleado, int idMetodo)
        {
            var result = await _empleadosClient.AsignarMetodo(idEmpleado, idMetodo);
            ViewBag.Message = result;
            return View();
        }

        public ActionResult CompletarMetodo()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CompletarMetodo(int idCompletado)
        {
            if (idCompletado < 0)
            {
                ViewBag.Message = "Por Favor, ingrese el Id del Metodo que desea marcar como completado";
                return View();
            }
            var result = await _empleadosClient.CompletarMetodo(idCompletado);

            ViewBag.Message = result;
            return View();
        }
    }
}