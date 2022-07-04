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
            return View();
        }

        public ActionResult BuscarCliente(string nome)
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

        public ActionResult Create(int clienteId)
        {
            _clienteRepository = new ClienteRepository();
            ViewBag.Cliente = _clienteRepository.Buscar(clienteId);

            return View();
        }

        [HttpPost] //POST: Diagnostico
        public ActionResult AdicionarDiagnostico(Diagnostico diagnostico)
        {
            _repository = new DiagnosticoRepository();

            _repository.Adicionar(diagnostico);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int clienteId)
        {
            _repository = new DiagnosticoRepository();
            var diagnostico = _repository.BuscarDiagnostico(clienteId);

            return View(diagnostico);
        }

        [HttpGet] //GET (pegar)
        public ActionResult Edit(int clienteId)
        {
            _repository = new DiagnosticoRepository();
            var diagnostico = _repository.BuscarDiagnostico(clienteId);

            return View(diagnostico);
        }

        [HttpPost] //POST (enviar)
        public ActionResult EditarDiagnostico(Diagnostico diagnostico)
        {
            _repository = new DiagnosticoRepository();
            _repository.Alterar(diagnostico);

            return RedirectToAction("Index"); // redireciona para action apontada
        }

    }
}