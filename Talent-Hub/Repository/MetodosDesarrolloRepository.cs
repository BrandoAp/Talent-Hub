using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent_Hub.Models;

namespace Talent_Hub.Repository
{
    public interface MetodosDesarrolloRepository
    {
        void agregarMetodoDesarrollo(Metodos_Desarrollo metodos_desarrollo);
        void updateMetodoDesarrollo(Metodos_Desarrollo metodos_desarrollo);
        List<Metodos_Desarrollo> buscarPorNombre(string Nombre_metodo);
    }
}
