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
    public class PosicionesDisponiblesController : ApiController
    {
        private readonly PosicionesDisponiblesService posicionesDisponiblesService;

        public PosicionesDisponiblesController()
        {
            posicionesDisponiblesService = new PosicionesDisponiblesService();
        }

        [HttpPost]
        [Route("agregar")]
        public IHttpActionResult AgregarPosicion(Posiciones_Disponibles posiciones)
        {
            if (posiciones == null)
                return BadRequest("Datos de la posicion no validos.");

            posicionesDisponiblesService.agregarPosicion(posiciones);
            return Ok("Nueva Posicion agregada exitosamente.");
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult UpdatePosicion(Posiciones_Disponibles posiciones)
        {
            if (posiciones == null || posiciones.Id_puesto <= 0)
                return BadRequest("Datos de la posicion no validas.");

            posicionesDisponiblesService.updatePosicion(posiciones);
            return Ok("Posicion disponibles actualizada exitosamente.");
        }

        [HttpGet]
        [Route("buscar/{nombre}")]
        public IHttpActionResult BuscarPorNombre(string nombre)
        {
            var posiciones = posicionesDisponiblesService.buscarPorNombrePosicion(nombre);
            if (posiciones == null || posiciones.Count == 0)
                return NotFound();
            
            return Ok(posiciones);
        }
    }
}
