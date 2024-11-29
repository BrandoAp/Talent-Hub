using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent_Hub.Models;

namespace Talent_Hub.Repository
{
    public interface UsuarioRepository
    {
        bool RegistrarUsuario(Usuario usuario);
        bool login(string username, string password);
        bool ExisteUsuario(string username);
    }
}
