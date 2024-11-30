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
    public class UsuarioClientController : Controller
    {
        private readonly UsuarioClient _usuarioClient;

        public UsuarioClientController()
        {
            _usuarioClient = new UsuarioClient();
        }
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Registrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var result = await _usuarioClient.RegistrarUsuario(usuario);
                ViewBag.Message = result;
                return View();
            }
            return View(usuario);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var result = await _usuarioClient.Login(usuario);
                ViewBag.Message = result;
                return View();
            }
            return View(usuario);
        }

        [HttpGet]
        public async Task<JsonResult> ExisteUsuario(string username)
        {
            var exists = await _usuarioClient.ExisteUsuario(username);
            return Json(exists, JsonRequestBehavior.AllowGet);
        }
    }
}