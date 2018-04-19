using EcommerceOsorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceOsorio.DAL
{
    public class UsuarioDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static List<Usuario> RetonarUsuarios()
        {
            return ctx.Usuarios.ToList();
        }

        public static void CadastrarUsuario(Usuario u)
        {
            ctx.Usuarios.Add(u);
            ctx.SaveChanges();
        }

        public static Usuario BuscarUsuarioPorEmailSenha(Usuario usuario)
        {
            return ctx.Usuarios.FirstOrDefault(x =>
                x.Senha.Equals(usuario.Senha) &&
                x.Email.Equals(usuario.Email));
        }
    }
}