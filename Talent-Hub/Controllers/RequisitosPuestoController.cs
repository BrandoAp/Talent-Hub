//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using Talent_Hub.Models;
//using Talent_Hub.Service;

//namespace Talent_Hub.Controllers
//{
//    [RoutePrefix("api/requisitosPuesto")]
//    public class RequisitosPuestoController : ApiController
//    {
//        private readonly RequisitosPuestoService requisitosPuestoService;

//        public RequisitosPuestoController()
//        {
//            requisitosPuestoService = new RequisitosPuestoService();
//        }

//        [HttpPost]
//        [Route("agregar")]
//        public IHttpActionResult AgregarRequisito(Requisitos_Puesto requisitos)
//        {
//            if (requisitos == null || requisitos.Id_puesto <= 0 || requisitos.Id_metodo <= 0)
//                return BadRequest("Datos del requisito no validos");

//            requisitosPuestoService.agregarRequisitos(requisitos);
//            return Ok("Requisito agregado correctamente");
//        }
//    }
//}
