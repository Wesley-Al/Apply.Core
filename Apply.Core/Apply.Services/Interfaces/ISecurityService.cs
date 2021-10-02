using Intru.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Intru.Services
{
    public interface ISecurityService
    {
        bool CadastraUsuario(Usuario usuario);
        bool AtenticaUsuario(Usuario usuario);
        Usuario GetByUsuLogin(string usuarioLogin);
        Usuario GetByCodUsuario(long usuCod);
        bool VerificaUsuario(string usuarioLogin);
    }
}
