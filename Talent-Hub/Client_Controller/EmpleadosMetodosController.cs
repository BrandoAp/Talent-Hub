using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Talent_Hub.Client;

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
            ViewBag.Empleados = result;
            return View();
        }

        public async Task<ActionResult> ObtenerConMetodosCompletados()
        {
            var result = await _empleadosMetodosClient.ObtenerEmpleadosConMetodosCompletados();
            ViewBag.Empleados = result;
            return View();
        }
    }
}