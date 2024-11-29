using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Talent_Hub.Service;

namespace Talent_Hub.Controllers
{
    [RoutePrefix("api/empleadosMetodos")]
    public class EmpleadosMetodosController : ApiController
    {
        private readonly EmpleadoMetodoService empleadoMetodoService;

        public EmpleadosMetodosController()
        {
            empleadoMetodoService = new EmpleadoMetodoService();
        }

        [HttpGet]
        [Route("asignados")]
        public IHttpActionResult ObtenerEmpleadosConMetodosAsignados()
        {
            var empleadosConMetodos = empleadoMetodoService.ObtenerEmpleadosConMetodosAsignados();
            if (empleadosConMetodos == null || empleadosConMetodos.Count == 0)
                return NotFound();

            return Ok(empleadosConMetodos);
        }

        [HttpGet]
        [Route("completados")]
        public IHttpActionResult ObtenerEmpleadosConMetodosCompletados()
        {
            var empleadosConMetodosCompletados = empleadoMetodoService.ObtenerEmpleadosConMetodosCompletados();

            if (empleadosConMetodosCompletados == null || empleadosConMetodosCompletados.Count == 0)
                return NotFound();

            return Ok(empleadosConMetodosCompletados);
        }
    }
}
