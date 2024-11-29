using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Talent_Hub.Models;
using Talent_Hub.Service;

namespace Talent_Hub.Controllers
{
    [RoutePrefix("api/metodosDesarrollo")]
    public class MetodosDesarrolloController : ApiController
    {
        private readonly MetodosDesarrolloService metodosDesarrolloService;

        public MetodosDesarrolloController()
        {
            metodosDesarrolloService = new MetodosDesarrolloService();
        }

        [HttpPost]
        [Route("agregar")]
        public IHttpActionResult AgregarMetodoDesarrollo(Metodos_Desarrollo metodo)
        {
            if (metodo == null)
                return BadRequest("Datos del metodo de desarrollo no validos");

            metodosDesarrolloService.agregarMetodoDesarrollo(metodo);
            return Ok("Metodo de desarrollo agregado exitosamente");
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult UpdateMetodoDesarrollo(Metodos_Desarrollo metodo)
        {
            if (metodo == null || metodo.Id_metodo <= 0)
                return BadRequest("Datos del metodo de desarrollo no validos");

            metodosDesarrolloService.updateMetodoDesarrollo(metodo);
            return Ok("Metodo de desarrollo actualizado exitosamente.");
        }

        [HttpGet]
        [Route("buscar/{nombre}")]
        public IHttpActionResult BuscarPorNombre(string nombre)
        {
            var metodos = metodosDesarrolloService.buscarPorNombre(nombre);
            if (metodos == null || metodos.Count == 0)
                return NotFound();

            return Ok(metodos);
        }
    }
}
