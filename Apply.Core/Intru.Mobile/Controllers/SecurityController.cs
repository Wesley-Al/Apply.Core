using Intru.Library;
using Intru.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intru.Mobile.Controllers
{
    [ApiController]
    [Route("mobile/[controller]")]
    public class SecurityController : ControllerBase
    {
        private IWalletService iWalletSVC;
        private ISecurityService iSecuritySVC;

        public SecurityController(IWalletService WalletSVC,
                                  ISecurityService SecuritySVC)
        {
            this.iSecuritySVC = SecuritySVC;
            this.iWalletSVC = WalletSVC;
        }

        [HttpPost("Cadastro")]
        public IActionResult Cadastro([FromBody] Usuario usuario)
        {
            Retorno<bool> retorno = new Retorno<bool>
            {
                Objeto = false,
                Success = true
            };

            try
            {
                if (!iSecuritySVC.VerificaUsuario(usuario.UsuarioLogin))
                {
                    if (iSecuritySVC.CadastraUsuario(usuario))
                    {
                        retorno.Objeto = true;
                    }
                    else
                    {
                        retorno.Objeto = false;
                        retorno.ErroMsg = "Ocorreu um erro durante a execução.";
                    }
                }
                else
                {
                    retorno.Objeto = false;
                    retorno.ErroMsg = "O Usuário informado ja existe";
                }

                return Ok(retorno);
            }
            catch (Exception error)
            {
                return Ok(error);
            }
        }

        [HttpGet("Autentication")]
        public IActionResult Autentication(string password, string user)
        {
            try
            {
                Usuario usuario = new Usuario();

                usuario.Senha = password;
                usuario.UsuarioLogin = user;

                if (iSecuritySVC.AtenticaUsuario(usuario))
                {
                    usuario = iSecuritySVC.GetByUsuLogin(usuario.UsuarioLogin);
                    object retorno = new
                    {
                        UsuNome = usuario.NomeUsuario,
                        UsuCod = usuario.CodUsuario
                    };

                    return Ok(retorno);
                }
                else
                {
                    return Ok(null);
                }                
            }
            catch (Exception error)
            {
                return Ok(error);
            }
        }
    }
}
