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
    public class UsuarioClientController : Controller
    {
        private readonly UsuarioClient _usuarioClient;
        private readonly UsuarioService usuarioService;

        public UsuarioClientController()
        {
            _usuarioClient = new UsuarioClient();
            usuarioService = new UsuarioService();
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
            if (usuario == null || string.IsNullOrEmpty(usuario.Nombre_usuario) || string.IsNullOrEmpty(usuario.Contrasena))
            {
                ViewBag.Message = "Ingrese todos los datos";
                return View();
            }
            bool isValid = usuarioService.login(usuario.Nombre_usuario, usuario.Contrasena);
            if (isValid)
                return RedirectToAction("AddEmpleado", "EmpleadosClient");
            else
            {
                ViewBag.Message = "Credenciales Incorrectas";
                return View();
            }
        }

        [HttpGet]
        public async Task<JsonResult> ExisteUsuario(string username)
        {
            var exists = await _usuarioClient.ExisteUsuario(username);
            return Json(exists, JsonRequestBehavior.AllowGet);
        }
    }
}