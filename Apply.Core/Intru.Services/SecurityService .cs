﻿using Intru.Library;
using System;
using System.Linq;

namespace Intru.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly Context Context;

        public SecurityService(Context context)
        {   
            Context = context;
        }

        public bool CadastraUsuario(Usuario usuario)
        {
            try
            {
                
                usuario.WalletNavigation = new Wallet();
                usuario.DtCadastro = DateTime.Now;

                usuario.WalletNavigation.DtCadastro = DateTime.Now;
                usuario.WalletNavigation.BankNavigation = Context.Banks.Where(x => x.CodBank == 1).FirstOrDefault();

                UsuarioWallet usuarioWallet = new UsuarioWallet();

                usuarioWallet.UWCod = default;

                usuarioWallet.CodUsuario = usuario;
                usuarioWallet.CodWallet = usuario.WalletNavigation;                

                Context.UsuarioWallet.Add(usuarioWallet);
                Context.Usuario.Add(usuario);

                Context.SaveChanges();

                return true;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        public Usuario GetByUsuLogin(string usuarioLogin)
        {
            return Context.Usuario.Where(x => x.UsuarioLogin == usuarioLogin).FirstOrDefault();
        }
        public Usuario GetByCodUsuario(long usuCod)
        {
            return Context.Usuario.Where(x => x.CodUsuario == usuCod).FirstOrDefault();

            
        }
        public bool AtenticaUsuario(Usuario usuario)
        {
            return Context.Usuario.FirstOrDefault(x => x.UsuarioLogin.Equals(usuario.UsuarioLogin) && x.Senha.Equals(usuario.Senha)) != null;
        }
        public bool VerificaUsuario(string usuarioLogin)
        {
            return Context.Usuario.FirstOrDefault(x => x.UsuarioLogin == usuarioLogin) != null;
        }
    }
}
