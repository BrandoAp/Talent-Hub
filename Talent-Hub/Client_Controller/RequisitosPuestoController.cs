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
    public class RequisitosPuestoController : Controller
    {

        private readonly RequisitosPuestoClient requisitosPuestoClient;

        public RequisitosPuestoController()
        {
            requisitosPuestoClient = new RequisitosPuestoClient();
        }
        // GET: RequisitosPuesto
        public ActionResult Agregar()
        {
            return View();
        }

        public async Task<ActionResult> AgregarRequisito(Requisitos_Puesto requisitos)
        {
            if (ModelState.IsValid)
            {
                var result = await requisitosPuestoClient.AgregarRequisito(requisitos);
                ViewBag.Message(result);
                return View();
            }

            return View(requisitos);
        }
    }
}