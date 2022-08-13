using AdminRestaureVida.Models;
using AdminRestaureVida.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminRestaureVida.Controllers
{
    public class SegmentoController : Controller
    {
        private SegmentoRepository _repository;
        private ProfissionalSegmentoRepository _repositoryProfissionalSegmento;

        // GET: Segmento
        public ActionResult Index()
        {
            if (Session["Autorizado"] != null)
            {
                _repository = new SegmentoRepository();

                var segmentos = _repository.BuscarTodos();
                return View(segmentos);
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

        [HttpPost] //POST: Segmento
        public ActionResult AdicionarSegmento(Segmento segmento)
        {
            if (Session["Autorizado"] != null)
            {
                _repository = new SegmentoRepository();
                _repository.Adicionar(segmento);

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
                _repository = new SegmentoRepository();
                var segmentoEscolhido = _repository.Buscar(id);
                return View(segmentoEscolhido);
            }
            else
                return RedirectToAction("Index", "Login");
        }

        [HttpPost] //POST (enviar)
        public ActionResult EditarSegmento(Segmento segmento)
        {
            if (Session["Autorizado"] != null)
            {
                _repository = new SegmentoRepository();
                _repository.Alterar(segmento);

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
                _repositoryProfissionalSegmento = new ProfissionalSegmentoRepository();
                _repositoryProfissionalSegmento.DeletarPorIdSegmento(id);

                _repository = new SegmentoRepository();
                _repository.Deletar(id);
                return RedirectToAction("Index"); // redireciona para action apontada
            }
            else
                return RedirectToAction("Index", "Login");
        }
    }
}