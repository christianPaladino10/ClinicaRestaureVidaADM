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
    public class DiagnosticoController : Controller
    {
        private ClienteRepository _clienteRepository;
        private DiagnosticoRepository _repository;

        // GET: Diagnostico
        public ActionResult Index()
        {
            if (Session["Autorizado"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Index", "Login");
        }

        public ActionResult BuscarCliente(string nome)
        {
            if (Session["Autorizado"] != null)
            {
                if (!string.IsNullOrEmpty(nome))
                {
                    _clienteRepository = new ClienteRepository();
                    _repository = new DiagnosticoRepository();

                    var clientes = _clienteRepository.BuscarPorNome(nome);

                    List<ClienteDiagnosticoViewModel> listVM = new List<ClienteDiagnosticoViewModel>();

                    foreach (var cliente in clientes)
                    {
                        ClienteDiagnosticoViewModel vm = new ClienteDiagnosticoViewModel();
                        vm.IdCliente = cliente.Id;
                        vm.Nome = cliente.Nome;
                        vm.TemDiagnostico = false;

                        var diagnostico = _repository.BuscarDiagnostico(cliente.Id);

                        if (diagnostico.Id > 0)
                            vm.TemDiagnostico = true;

                        listVM.Add(vm);
                    }

                    ViewBag.Clientes = listVM;
                }

                return View("Index");
            }
            else
                return RedirectToAction("Index", "Login");
        }

        public ActionResult Create(int clienteId)
        {
            if (Session["Autorizado"] != null)
            {
                _clienteRepository = new ClienteRepository();
                ViewBag.Cliente = _clienteRepository.Buscar(clienteId);

                return View();
            }
            else
                return RedirectToAction("Index", "Login");
        }

        [HttpPost] //POST: Diagnostico
        public ActionResult AdicionarDiagnostico(Diagnostico diagnostico)
        {
            if (Session["Autorizado"] != null)
            {
                _repository = new DiagnosticoRepository();
                diagnostico.IdProfissional = Convert.ToInt32(Session["Autorizado"]);

                _repository.Adicionar(diagnostico);

                TempData["MensagemSucesso"] = "Salvo com sucesso!";

                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index", "Login");
        }

        public ActionResult Details(int clienteId)
        {
            if (Session["Autorizado"] != null)
            {
                _repository = new DiagnosticoRepository();
                var diagnostico = _repository.BuscarDiagnostico(clienteId);

                return View(diagnostico);
            }
            else
                return RedirectToAction("Index", "Login");
        }

        [HttpGet] //GET (pegar)
        public ActionResult Edit(int clienteId)
        {
            if (Session["Autorizado"] != null)
            {
                _repository = new DiagnosticoRepository();
                var diagnostico = _repository.BuscarDiagnostico(clienteId);

                return View(diagnostico);
            }
            else
                return RedirectToAction("Index", "Login");
        }

        [HttpPost] //POST (enviar)
        public ActionResult EditarDiagnostico(Diagnostico diagnostico)
        {
            if (Session["Autorizado"] != null)
            {
                diagnostico.IdProfissional = Convert.ToInt32(Session["Autorizado"]);

                _repository = new DiagnosticoRepository();
                _repository.Alterar(diagnostico);

                TempData["MensagemSucesso"] = "Salvo com sucesso!";

                return RedirectToAction("Index"); // redireciona para action apontada
            }
            else
                return RedirectToAction("Index", "Login");
        }

    }
}