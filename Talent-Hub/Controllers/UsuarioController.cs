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
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        private readonly UsuarioService usuarioService;

        public UsuarioController()
        {
            usuarioService = new UsuarioService();
        }

        [HttpPost]
        [Route("registrar")]
        public HttpResponseMessage RegistrarUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null || string.IsNullOrEmpty(usuario.Nombre_usuario) || string.IsNullOrEmpty(usuario.Contrasena))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Datos incompletos");

            if (usuarioService.ExisteUsuario(usuario.Nombre_usuario))
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "El nombre usuario ya existe");

            bool result = usuarioService.RegistrarUsuario(usuario);
            if (result)
                return Request.CreateResponse(HttpStatusCode.Created, "Usuario registrado exitosamente");
            else
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error con el servidor");
        }

        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login([FromBody] Usuario usuario)
        {
            if (usuario == null || string.IsNullOrEmpty(usuario.Nombre_usuario) || string.IsNullOrEmpty(usuario.Contrasena))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Por favor ingrese todos los datos");

            bool isValid = usuarioService.login(usuario.Nombre_usuario, usuario.Contrasena);
            if (isValid)
                return Request.CreateResponse(HttpStatusCode.OK, "Inicio de sesion exitoso");
            else
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Credenciales Incorrectas");
        }

        [HttpGet]
        [Route("existe/{username}")]
        public HttpResponseMessage ExisteUsuario(string username)
        {
            if (string.IsNullOrEmpty(username))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "El nombre de usuario es obligatorio");

            bool exits = usuarioService.ExisteUsuario(username);
            return Request.CreateResponse(HttpStatusCode.OK, exits);
        }
    }
}
