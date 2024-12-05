//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;
//using Talent_Hub.Client;
//using Talent_Hub.Models;

//namespace Talent_Hub.Client_Controller
//{
//    public class MetodosDesarrolloController : Controller
//    {
//        private readonly MetodosDesarrolloClient metodosDesarrolloClient;

//        public MetodosDesarrolloController()
//        {
//            metodosDesarrolloClient = new MetodosDesarrolloClient();
//        }
        
//        public ActionResult Agregar()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<ActionResult> AgregarMetodo(Metodos_Desarrollo metodo)
//        {
//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    var result = await metodosDesarrolloClient.AgregarMetodo(metodo);
//                    ViewBag.Message = "Método agregado correctamente";
//                    return View();
//                } catch (Exception ex)
//                {
//                    ViewBag.Message = $"Error al agregar el metodo: {ex.Message}";
//                    return View(metodo);
//                }
//            }

//            return View(metodo);
//        }

//        public ActionResult Actualizar()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<ActionResult> ActualizarMetodo(Metodos_Desarrollo metodo)
//        {
//            if (ModelState.IsValid)
//            {
//                var result = await metodosDesarrolloClient.ActualizarMetodo(metodo);
//                ViewBag.Message = "Método actualizado correctamente";
//                return View();
//            }

//            return View(metodo);
//        }

//        public ActionResult Buscar()
//        {
//            return View();
//        }

//        [HttpGet]
//        public async Task<ActionResult> BuscarPorNombre(string nombre)
//        {
//            if (string.IsNullOrEmpty(nombre))
//            {
//                ViewBag.Message = "Por favor ingrese el nombre del método.";
//                return View();
//            }

//            var result = await metodosDesarrolloClient.BuscarMetodoPorNombre(nombre);
//            ViewBag.Message = result;
//            return View();
//        }
//    }
//}