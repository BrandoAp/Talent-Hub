using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent_Hub.Models;

namespace Talent_Hub.Repository
{
    public interface PosicionesDisponiblesRepository
    {
        //List<Posiciones_Disponibles> obtenerPosiciones();
        void agregarPosicion(Posiciones_Disponibles posiciones_disponibles);
        List<Posiciones_Disponibles> buscarPorNombrePosicion(string nombre_posicion);
    }
}
