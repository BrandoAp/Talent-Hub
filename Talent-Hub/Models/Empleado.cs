using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Talent_Hub.Models
{
    public class Empleado
    {
        public int Id_empleado { get; set; }
        public string Nombre_empleado { get; set; }
        public string Email_empleado { get; set; }
        public string Posicion_actual { get; set; }
        public string Habilidades { get; set; }
    }
}