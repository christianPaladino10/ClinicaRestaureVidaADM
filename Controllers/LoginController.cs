using AdminRestaureVida.Models;
using AdminRestaureVida.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminRestaureVida.Controllers
{
    public class LoginController : Controller
    {
        private ProfissionalRepository _repository;

        // GET: Login
        public ActionResult Index()
        {
            if (Session["Erro"] != null)
                ViewBag.Erro = Session["Erro"].ToString();

            return View();
        }

        [HttpPost]
        public void Login()
        {
            Profissional profissional = new Profissional();
            profissional.Email = Request["email"];
            profissional.Senha = Request["senha"];

            _repository = new ProfissionalRepository();
            Profissional login = _repository.Login(profissional);

            if (login.Id != 0)
            {
                Session["Autorizado"] = login.Id;
                Session["Perfil"] = login.Perfil;

                //    new Profissional() 
                //{
                //    Id = login.Id,
                //    Celular = login.Celular,
                //    CPF = login.CPF,
                //    DataCadastro = login.DataCadastro,
                //    DataNascimento = login.DataNascimento,
                //    Email = login.Email,
                //    Nome = login.Nome,
                //    SegmentoId = login.SegmentoId,
                //    Telefone = login.Telefone
                //};
                Session.Remove("Erro");
                Response.Redirect("/Consulta/Index");
            }
            else
            {
                Session["Erro"] = "Senha ou Usuário inválidos";
                Response.Redirect("/Login/Index");
            }
        }

        public ActionResult Sair()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }

    }
}