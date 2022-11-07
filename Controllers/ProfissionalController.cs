using AdminRestaureVida.Models;
using AdminRestaureVida.Repository;
using AdminRestaureVida.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static AdminRestaureVida.ViewModel.ProfissionalSegmentoViewModel;

namespace AdminRestaureVida.Controllers
{
    public class ProfissionalController : Controller
    {
        private ProfissionalRepository _repository;
        private SegmentoRepository _repositorySegmento;
        private ProfissionalSegmentoRepository _repositoryProfissionalSegmento;
        // GET: Profissional
        public ActionResult Index()
        {
            if (Session["Autorizado"] != null)
            {
                _repository = new ProfissionalRepository();

                var profissionais = _repository.BuscarTodos();
                return View(profissionais);
            }
            else
                return RedirectToAction("Index", "Login");
        }

        public ActionResult Create()
        {
            if (Session["Autorizado"] != null)
            {
                _repositorySegmento = new SegmentoRepository();
                var segmentos = _repositorySegmento.BuscarTodos();

                ProfissionalSegmentoViewModel vm = new ProfissionalSegmentoViewModel();

                List<CheckBoxSegmento> listaCheckBoxSegmento = new List<CheckBoxSegmento>();

                foreach (var item in segmentos)
                {
                    CheckBoxSegmento CheckBoxSegmento = new CheckBoxSegmento
                    {
                        Id = item.Id,
                        Description = item.Nome,
                        Checked = false
                    };

                    listaCheckBoxSegmento.Add(CheckBoxSegmento);
                }

                vm.ListaCheckBoxSegmento = listaCheckBoxSegmento;

                return View(vm);
            }
            else
                return RedirectToAction("Index", "Login");
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
        public ActionResult AdicionarProfissional(ProfissionalSegmentoViewModel profissionalVM)
        {
            if (Session["Autorizado"] != null)
            {
                _repository = new ProfissionalRepository();
                _repositoryProfissionalSegmento = new ProfissionalSegmentoRepository();

                Profissional profissional = new Profissional
                {
                    Celular = profissionalVM.Celular,
                    CPF = profissionalVM.CPF,
                    DataNascimento = profissionalVM.DataNascimento,
                    Email = profissionalVM.Email,
                    Nome = profissionalVM.Nome,
                    Senha = profissionalVM.Senha,
                    Telefone = profissionalVM.Telefone,
                    Perfil = profissionalVM.Perfil
                };

                int idProfissional = _repository.Adicionar(profissional);

                List<ProfissionalSegmento> listaProfissionalSegmento = new List<ProfissionalSegmento>();

                var lista = profissionalVM.ListaCheckBoxSegmento.Where(x => x.Checked == true);

                foreach (var segmento in lista)
                {
                    ProfissionalSegmento ps = new ProfissionalSegmento();
                    ps.ProfissionalId = idProfissional;
                    ps.SegmentoId = segmento.Id;

                    listaProfissionalSegmento.Add(ps);
                }

                _repositoryProfissionalSegmento.Adicionar(listaProfissionalSegmento);

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
                _repository = new ProfissionalRepository();
                _repositoryProfissionalSegmento = new ProfissionalSegmentoRepository();
                _repositorySegmento = new SegmentoRepository();

                var profissionalEscolhido = _repository.Buscar(id);

                ProfissionalSegmentoViewModel vm = new ProfissionalSegmentoViewModel();
                vm.ProfissionalId = id;
                vm.Celular = profissionalEscolhido.Celular;
                vm.CPF = profissionalEscolhido.CPF;
                vm.DataNascimento = profissionalEscolhido.DataNascimento;
                vm.Email = profissionalEscolhido.Email;
                vm.Nome = profissionalEscolhido.Nome;
                vm.Telefone = profissionalEscolhido.Telefone;
                vm.Perfil = profissionalEscolhido.Perfil;

                var segmentos = _repositorySegmento.BuscarTodos();
                var listaProfissionalSegmento = _repositoryProfissionalSegmento.Buscar(id);

                var segmentosEscolhidos = listaProfissionalSegmento.Where(b => segmentos.Any(a => a.Id == b.SegmentoId));

                List<CheckBoxSegmento> listaCheckBoxProfissionalSegmento = new List<CheckBoxSegmento>();

                foreach (var item in segmentos)
                {
                    CheckBoxSegmento CheckBoxProfissionalSegmento = new CheckBoxSegmento();
                    CheckBoxProfissionalSegmento.Id = item.Id;
                    CheckBoxProfissionalSegmento.Description = item.Nome;

                    if (segmentosEscolhidos.Any(p => p.SegmentoId == item.Id))
                        CheckBoxProfissionalSegmento.Checked = true;
                    else
                        CheckBoxProfissionalSegmento.Checked = false;

                    listaCheckBoxProfissionalSegmento.Add(CheckBoxProfissionalSegmento);
                }

                vm.ListaCheckBoxSegmento = listaCheckBoxProfissionalSegmento;

                return View(vm);
            }
            else
                return RedirectToAction("Index", "Login");
        }

        [HttpPost] //POST (enviar)
        public ActionResult EditarProfissional(ProfissionalSegmentoViewModel profissionalVM)
        {
            if (Session["Autorizado"] != null)
            {
                _repository = new ProfissionalRepository();
                _repositoryProfissionalSegmento = new ProfissionalSegmentoRepository();

                Profissional profissional = new Profissional
                {
                    Id = profissionalVM.ProfissionalId,
                    Celular = profissionalVM.Celular,
                    CPF = profissionalVM.CPF,
                    DataNascimento = profissionalVM.DataNascimento,
                    Nome = profissionalVM.Nome,
                    Telefone = profissionalVM.Telefone,
                    Perfil = profissionalVM.Perfil
                };

                _repository.Alterar(profissional);

                var lista = profissionalVM.ListaCheckBoxSegmento.Where(x => x.Checked == true);

                List<ProfissionalSegmento> listaProfissionalSegmento = new List<ProfissionalSegmento>();

                foreach (var segmento in lista)
                {
                    ProfissionalSegmento ps = new ProfissionalSegmento();
                    ps.ProfissionalId = profissional.Id;
                    ps.SegmentoId = segmento.Id;

                    listaProfissionalSegmento.Add(ps);
                }

                _repositoryProfissionalSegmento.Deletar(profissional.Id);
                _repositoryProfissionalSegmento.Adicionar(listaProfissionalSegmento);

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
                _repository = new ProfissionalRepository();
                _repository.Deletar(id);
                return RedirectToAction("Index"); // redireciona para action apontada
            }
            else
                return RedirectToAction("Index", "Login");
        }

        public ActionResult Details(int id)
        {
            if (Session["Autorizado"] != null)
            {
                _repository = new ProfissionalRepository();
                _repositorySegmento = new SegmentoRepository();
                _repositoryProfissionalSegmento = new ProfissionalSegmentoRepository();

                var profissionalEscolhido = _repository.Buscar(id);
                var segmentos = _repositorySegmento.BuscarTodos();
                var listaProfissionalSegmento = _repositoryProfissionalSegmento.Buscar(id);

                var segmentosEscolhidos = segmentos.Where(b => listaProfissionalSegmento.Any(a => a.SegmentoId == b.Id));

                List<string> lista = new List<string>();

                foreach (var item in segmentosEscolhidos)
                {
                    lista.Add(item.Nome);
                }

                ViewBag.Segmentos = lista;

                return View(profissionalEscolhido);
            }
            else
                return RedirectToAction("Index", "Login");
        }
    }
}