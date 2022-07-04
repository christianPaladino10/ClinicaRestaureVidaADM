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
            _repository = new ProcedimentoRepository();

            var procedimentos = _repository.BuscarTodos();
            return View(procedimentos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost] //POST: Procedimento
        public ActionResult AdicionarProcedimento(Procedimento procedimento)
        {
            _repository = new ProcedimentoRepository();

            _repository.Adicionar(procedimento);
            return RedirectToAction("Index");
        }

        [HttpGet] //GET (pegar)
        public ActionResult Edit(int id)
        {
            _repository = new ProcedimentoRepository();
            var procedimentoEscolhido = _repository.Buscar(id);
            return View(procedimentoEscolhido);
        }

        [HttpPost] //POST (enviar)
        public ActionResult EditarProcedimento(Procedimento procedimento)
        {
            _repository = new ProcedimentoRepository();
            _repository.Alterar(procedimento);

            return RedirectToAction("Index"); // redireciona para action apontada
        }

        public ActionResult Delete(int id)
        {
            _repository = new ProcedimentoRepository();
            _repository.Deletar(id);
            return RedirectToAction("Index"); // redireciona para action apontada
        }
    }
}