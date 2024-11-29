using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent_Hub.Models;

namespace Talent_Hub.Repository
{
    public interface EmpleadosMetodosRepository
    {
        List<Empleados_Metodos> ObtenerEmpleadosConMetodosAsignados();
        List<Empleados_Metodos> ObtenerEmpleadosConMetodosCompletados();
    }
}
