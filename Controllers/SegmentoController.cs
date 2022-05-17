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

        // GET: Segmento
        public ActionResult Index()
        {
            _repository = new SegmentoRepository();

            var segmentos = _repository.BuscarTodos();
            return View(segmentos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost] //POST: Segmento
        public ActionResult AdicionarSegmento(Segmento segmento)
        {
            if (ModelState.IsValid) // Vai no Model e verifica os DataAnnotations se são válidos
            {
                _repository = new SegmentoRepository();

                _repository.Adicionar(segmento);
                return RedirectToAction("Index");
            }
            return View(segmento);
        }

        [HttpGet] //GET (pegar)
        public ActionResult Edit(int id)
        {
            _repository = new SegmentoRepository();
            var segmentoEscolhido = _repository.Buscar(id);
            return View(segmentoEscolhido);
        }

        [HttpPost] //POST (enviar)
        public ActionResult EditarSegmento(Segmento segmento)
        {
            if (ModelState.IsValid) // Vai no Model e verifica os DataAnnotations se são válidos
            {
                _repository = new SegmentoRepository();
                _repository.Alterar(segmento);
            }

            return RedirectToAction("Index"); // redireciona para action apontada
        }

        public ActionResult Delete(int id)
        {
            _repository = new SegmentoRepository();
            _repository.Deletar(id);
            return RedirectToAction("Index"); // redireciona para action apontada
        }
    }
}