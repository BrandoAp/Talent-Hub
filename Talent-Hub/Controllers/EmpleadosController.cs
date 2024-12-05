using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Management;
using Talent_Hub.Models;
using Talent_Hub.Service;

namespace Talent_Hub.Controllers
{
    [RoutePrefix("api/empleados")]
    public class EmpleadosController : ApiController
    {
        private readonly EmpleadoService empleadoService;
        public EmpleadosController()
        {
            empleadoService = new EmpleadoService();
        }
        [HttpPost]
        [Route("añadir")]
        public IHttpActionResult AddEmpleado(Empleado empleado)
        {
            if (empleado == null)
                return BadRequest("Datos del empleado no validos");

            empleadoService.añadirEmpleado(empleado);
            return Ok("Empleado agregado exitosamente");
        }

        [HttpGet]
        [Route("listarEmpleados")]
        public IHttpActionResult listarEmpleados()
        {
            var empleados = empleadoService.listarEmpleados();
            if (empleados == null || empleados.Count == 0)
                return NotFound();

            return Ok(empleados);
        }

        [HttpGet]
        [Route("buscar/{nombre}")]
        public IHttpActionResult BuscarPorNombre(string nombre)
        {
            var empleados = empleadoService.buscarPorNombre(nombre);
            if (empleados == null || empleados.Count == 0)
                return NotFound();

            return Ok(empleados);
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult UpdateEmpleado(Empleado empleado)
        {
            if (empleado == null || empleado.Id_empleado <= 0)
                return BadRequest("Datos del empleado no validos");

            empleadoService.UpdateEmpleado(empleado);
            return Ok("Empleado actualizado exitosamente");
        }

        [HttpPost]
        [Route("asignarMetodo")]
        public IHttpActionResult AsignarMetodo([FromUri] int idEmpleado, [FromUri] int idMetodo)
        {
            if (idEmpleado <= 0 || idMetodo <= 0)
                return BadRequest("IDs no validos");

            empleadoService.AsignarMetodo(idEmpleado, idMetodo);
            return Ok("Metodo de desarrollo asignado correctamente");
        }

        [HttpPost]
        [Route("completarMetodo")]
        public IHttpActionResult CompletarMetodo(int idCompletado)
        {
            if (idCompletado <= 0)
                return BadRequest("Id no valido");

            empleadoService.AsignarMetodoCompletado(idCompletado);
            return Ok($"Metodo con id: {idCompletado} marcado como completado");
        }
    }
}
