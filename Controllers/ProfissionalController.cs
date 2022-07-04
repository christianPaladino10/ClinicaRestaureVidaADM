using AdminRestaureVida.Models;
using AdminRestaureVida.Repository;
using AdminRestaureVida.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminRestaureVida.Controllers
{
    public class ProfissionalController : Controller
    {
        private ProfissionalRepository _repository;
        private SegmentoRepository _repositorySegmento;

        // GET: Profissional
        public ActionResult Index()
        {
            _repository = new ProfissionalRepository();

            var profissionais = _repository.BuscarTodos();
            return View(profissionais);
        }

        public ActionResult Create()
        {
            _repositorySegmento = new SegmentoRepository();
            var segmentos = _repositorySegmento.BuscarTodos();
            ViewBag.Segmentos = new SelectList(GetSegmentoVM(segmentos), "Id", "Title");

            return View();
        }

        private List<SegmentoViewModel> GetSegmentoVM(List<Segmento> segmentos)
        {
            List<SegmentoViewModel> segmentoViewModels = new List<SegmentoViewModel>();

            foreach (var segmento in segmentos)
            {
                segmentoViewModels.Add(new SegmentoViewModel() { Id = segmento.Id, Title = segmento.Nome });
            }

            return segmentoViewModels;
        }

        [HttpPost] //POST: Profissional
        public ActionResult AdicionarProfissional(Profissional profissional)
        {
            _repository = new ProfissionalRepository();

            _repository.Adicionar(profissional);
            return RedirectToAction("Index");
        }

        [HttpGet] //GET (pegar)
        public ActionResult Edit(int id)
        {
            _repository = new ProfissionalRepository();
            var profissionalEscolhido = _repository.Buscar(id);
            return View(profissionalEscolhido);
        }

        [HttpPost] //POST (enviar)
        public ActionResult EditarProfissional(Profissional profissional)
        {
            _repository = new ProfissionalRepository();
            _repository.Alterar(profissional);

            return RedirectToAction("Index"); // redireciona para action apontada
        }

        public ActionResult Delete(int id)
        {
            _repository = new ProfissionalRepository();
            _repository.Deletar(id);
            return RedirectToAction("Index"); // redireciona para action apontada
        }

        public ActionResult Details(int id)
        {
            _repository = new ProfissionalRepository();
            var profissionalEscolhido = _repository.Buscar(id);
            return View(profissionalEscolhido);
        }
    }
}