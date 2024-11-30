using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Talent_Hub.Client;
using Talent_Hub.Models;

namespace Talent_Hub.Client_Controller
{
    public class PosicionesDisponiblesController : Controller
    {
        private readonly PosicionesDisponiblesClient _posicionesDisponiblesClient;

        public PosicionesDisponiblesController()
        {
            _posicionesDisponiblesClient = new PosicionesDisponiblesClient();
        }
        // GET: PosicionesDisponibles
        public ActionResult AgregarPosicion()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AgregarPosicion(Posiciones_Disponibles posicion)
        {
            if (ModelState.IsValid)
            {
                var result = await _posicionesDisponiblesClient.AgregarPosicion(posicion);
                ViewBag.Message = result;
                return View();
            }

            return View(posicion);
        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ActualizarPosicion(Posiciones_Disponibles posicion)
        {
            if (ModelState.IsValid)
            {
                var result = await _posicionesDisponiblesClient.ActualizarPosicion(posicion);
                ViewBag.Message = result;
                return View();
            }

            return View(posicion);
        }

        public ActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> BuscarPorNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                ViewBag.Message = "Por favor ingrese el nombre de la posición.";
                return View();
            }

            var result = await _posicionesDisponiblesClient.BuscarPosicionPorNombre(nombre);
            ViewBag.Message = result;
            return View();
        }
    }
}