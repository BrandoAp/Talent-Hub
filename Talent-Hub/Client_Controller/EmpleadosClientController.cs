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
    public class EmpleadosClientController : Controller
    {
        private readonly EmpleadosClient _empleadosClient;

        public EmpleadosClientController()
        {
            _empleadosClient = new EmpleadosClient();
        }
        // GET: EmpleadosClient
        public ActionResult AddEmpleado()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddEmpleado(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                var result = await _empleadosClient.AddEmpleado(empleado);
                ViewBag.Message = result;
                return View();
            }
            return View(empleado);
        }

        public async Task<ActionResult> BuscarPorNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                ViewBag.Message = "Por favor ingrese el nombre del empleado";
                return View();
            }
            var result = await _empleadosClient.BuscarPorNombre(nombre);
            ViewBag.Empleados = result;
            return View();
        }

        public ActionResult UpdateEmpleado(int id)
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
            var result = await _empleadosClient.CompletarMetodo(idCompletado);
            ViewBag.Message = result;
            return View();
        }
    }
}