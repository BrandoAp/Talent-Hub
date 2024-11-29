using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent_Hub.Models;

namespace Talent_Hub.Repository
{
    public interface EmpleadoRepository
    {
        void añadirEmpleado(Empleado empleado);
        List<Empleado> buscarPorNombre(string Nombre_empleado);
        void UpdateEmpleado(Empleado empleado);
        void AsignarMetodo(int Id_empleado, int Id_metodo);
        void AsignarMetodoCompletado(int Id_completado);
    }
}
