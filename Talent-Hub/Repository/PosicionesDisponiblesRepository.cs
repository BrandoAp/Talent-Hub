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
        void agregarPosicion(Posiciones_Disponibles posiciones_disponibles);
        void updatePosicion(Posiciones_Disponibles posiciones_Disponibles);
        List<Posiciones_Disponibles> buscarPorNombrePosicion(string nombre_posicion);
    }
}
