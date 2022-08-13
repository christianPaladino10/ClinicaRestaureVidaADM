using AdminRestaureVida.Models;
using AdminRestaureVida.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminRestaureVida.Controllers
{
    public class ProcedimentoController : Controller
    {
        private ProcedimentoRepository _repository;

        // GET: Procedimento
        public ActionResult Index()
        {
            if (Session["Autorizado"] != null)
            {
                _repository = new ProcedimentoRepository();

                var procedimentos = _repository.BuscarTodos();
                return View(procedimentos);
            }
            else
                return RedirectToAction("Index", "Login");
        }

        public ActionResult Create()
        {
            if (Session["Autorizado"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Index", "Login");
        }

        [HttpPost] //POST: Procedimento
        public ActionResult AdicionarProcedimento(Procedimento procedimento)
        {
            if (Session["Autorizado"] != null)
            {
                _repository = new ProcedimentoRepository();
                _repository.Adicionar(procedimento);

                TempData["MensagemSucesso"] = "Salvo com sucesso!";

                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index", "Login");
        }

        [HttpGet] //GET (pegar)
        public ActionResult Edit(int id)
        {
            if (Session["Autorizado"] != null)
            {
                _repository = new ProcedimentoRepository();
                var procedimentoEscolhido = _repository.Buscar(id);
                return View(procedimentoEscolhido);
            }
            else
                return RedirectToAction("Index", "Login");
        }

        [HttpPost] //POST (enviar)
        public ActionResult EditarProcedimento(Procedimento procedimento)
        {
            if (Session["Autorizado"] != null)
            {
                _repository = new ProcedimentoRepository();
                _repository.Alterar(procedimento);

                TempData["MensagemSucesso"] = "Salvo com sucesso!";

                return RedirectToAction("Index"); // redireciona para action apontada
            }
            else
                return RedirectToAction("Index", "Login");
        }

        public ActionResult Delete(int id)
        {
            if (Session["Autorizado"] != null)
            {
                _repository = new ProcedimentoRepository();
                _repository.Deletar(id);
                return RedirectToAction("Index"); // redireciona para action apontada
            }
            else
                return RedirectToAction("Index", "Login");
        }
    }
}