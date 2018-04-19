using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommerceOsorio.Models;
using EcommerceOsorio.DAL;
using System.Text;
using Newtonsoft.Json;
using System.Web.Security;

namespace EcommerceOsorio.Controllers
{
    public class UsuariosController : Controller
    {

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(UsuarioDAO.RetonarUsuarios());
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioId,Nome,Email,Senha,ConfirmacaoSenha,Cep,Logradouro,Bairro,Localidade,Uf")] Usuario usuario)
        {
            usuario = (Usuario)HttpContext.Session["Usuario"];

            if (ModelState.IsValid)
            {
                UsuarioDAO.CadastrarUsuario(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            Usuario usuario = (Usuario)HttpContext.Session["Usuario"];
            return View(usuario);
        }

        [HttpPost]
        public ActionResult PesquisarCep(Usuario usuario)
        {
            string url = "https://viacep.com.br/ws/" + usuario.Cep + "/json/";
            WebClient client = new WebClient();
            try
            {
                Usuario usuarioAux = usuario;
                //Consumindo os dados do Viacep
                string resultado = client.DownloadString(@url);
                //Converter para UTF8
                byte[] bytes = Encoding.Default.GetBytes(resultado);
                resultado = Encoding.UTF8.GetString(bytes);
                //Converter os dados da string em objeto
                usuario = JsonConvert.DeserializeObject<Usuario>(resultado);

                usuario.ConfirmacaoSenha = usuarioAux.ConfirmacaoSenha;
                usuario.Email = usuarioAux.Email;
                usuario.Nome = usuarioAux.Nome;
                usuario.Senha = usuarioAux.Senha;

                //Passar o objeto preenchido para outra Action
                HttpContext.Session["Usuario"] = usuario;
            }
            catch (Exception)
            {
                TempData["Mensagem"] = "CEP inválido!";
            }
            return RedirectToAction("Create", "Usuarios");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario, bool chkConectado)
        {
            usuario = UsuarioDAO.BuscarUsuarioPorEmailSenha(usuario);
            if (usuario != null)
            {
                //Login
                FormsAuthentication.SetAuthCookie(usuario.Email, chkConectado);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //Mensagem de erro
                ModelState.AddModelError("", "E-mail ou senha inválidos!");
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Usuarios");
        }

    }
}
