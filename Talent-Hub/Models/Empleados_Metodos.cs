using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Talent_Hub.Models
{
    public class Empleados_Metodos
    {
        public int Id_empleado { get; set; }
        public string Nombre_empleado { get; set; }
        public string Email_empleado { get; set; }
        public string Posicion_actual { get; set; }
        public int Id_metodo { get; set; }
        public string Nombre_metodo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_asignado { get; set; }
    }
}