using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Talent_Hub.Models
{
    public class Metodos_Completados
    {
        public int Id_completado { get; set; }
        public int Id_empleado { get; set; }
        public int Id_metodo { get; set; }
        public DateTime Fecha_completado { get; set; }
    }
}