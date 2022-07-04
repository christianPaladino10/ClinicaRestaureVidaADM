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
    public class ConsultaController : Controller
    {
        private ClienteRepository _clienteRepository;
        private ProcedimentoRepository _procedimentoRepository;
        private ProcedimentoConsultaRepository _procedimentoConsultaRepository;
        private ConsultaRepository _repository;
        private ProfissionalRepository _profissionalRepository;

        // GET: Consulta
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            _procedimentoRepository = new ProcedimentoRepository();
            var procedimentos = _procedimentoRepository.BuscarTodos();

            ConsultaViewModel vm = new ConsultaViewModel();

            List<CheckBoxProcedimento> listaCheckBoxProcedimentos = new List<CheckBoxProcedimento>();

            foreach (var item in procedimentos)
            {
                CheckBoxProcedimento CheckBoxProcedimentos = new CheckBoxProcedimento
                {
                    Id = item.Id,
                    Description = item.Nome,
                    Checked = false
                };

                listaCheckBoxProcedimentos.Add(CheckBoxProcedimentos);
            }

            vm.ListaCheckBoxProcedimento = listaCheckBoxProcedimentos;

            return View(vm);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            _repository = new ConsultaRepository();
            _clienteRepository = new ClienteRepository();
            _profissionalRepository = new ProfissionalRepository();
            _procedimentoConsultaRepository = new ProcedimentoConsultaRepository();
            _procedimentoRepository = new ProcedimentoRepository();

            var consulta = _repository.Buscar(id);
            var cliente = _clienteRepository.Buscar(consulta.IdCliente);
            var profissional = _profissionalRepository.Buscar(consulta.ProfissionalId);
            var procedimentoConsulta = _procedimentoConsultaRepository.Buscar(consulta.Id);

            ConsultaViewModel vm = new ConsultaViewModel();
            vm.DataCriacaoConsulta = consulta.DataCriacao;
            vm.NomeCliente = cliente.Nome;
            vm.NomeProfissional = profissional.Nome;
            vm.Observacao = consulta.Observacao;
            vm.IdCliente = cliente.Id;
            vm.IdProfissional = profissional.Id;
            vm.IdConsulta = id;

            var procedimentos = _procedimentoRepository.BuscarTodos();
            var procedimentosEscolhidos = procedimentoConsulta.Where(b => procedimentos.Any(a => a.Id == b.IdProcedimento));

            List<CheckBoxProcedimento> listaCheckBoxProcedimentos = new List<CheckBoxProcedimento>();

            foreach (var item in procedimentos)
            {
                CheckBoxProcedimento CheckBoxProcedimentos = new CheckBoxProcedimento();
                CheckBoxProcedimentos.Id = item.Id;
                CheckBoxProcedimentos.Description = item.Nome;

                if (procedimentosEscolhidos.Any(p => p.IdProcedimento == item.Id))
                    CheckBoxProcedimentos.Checked = true;
                else
                    CheckBoxProcedimentos.Checked = false;

                listaCheckBoxProcedimentos.Add(CheckBoxProcedimentos);
            }

            vm.ListaCheckBoxProcedimento = listaCheckBoxProcedimentos;

            return View(vm);
        }

        [HttpPost] //POST (enviar)
        public ActionResult EditarConsulta(ConsultaViewModel consultaVm)
        {
            _repository = new ConsultaRepository();

            Consulta consulta = new Consulta
            {
                Id = consultaVm.IdConsulta,
                IdCliente = consultaVm.IdCliente,
                Observacao = consultaVm.Observacao
            };

            _repository.Alterar(consulta);

            var lista = consultaVm.ListaCheckBoxProcedimento.Where(x => x.Checked == true);

            List<ProcedimentoConsulta> listaProcedimentoConsulta = new List<ProcedimentoConsulta>();

            foreach (var procedimento in lista)
            {
                ProcedimentoConsulta pc = new ProcedimentoConsulta();
                pc.IdProcedimento = procedimento.Id;
                pc.IdConsulta = consultaVm.IdConsulta;

                listaProcedimentoConsulta.Add(pc);
            }

            _procedimentoConsultaRepository = new ProcedimentoConsultaRepository();
            _procedimentoConsultaRepository.Deletar(consulta.Id);
            _procedimentoConsultaRepository.Adicionar(listaProcedimentoConsulta);


            return Redirect("/Consulta/Historico/" + consulta.IdCliente);
        }

        public ActionResult Delete(int id)
        {
            _repository = new ConsultaRepository();
            _repository.Deletar(id);
            //return RedirectToAction("Historico");

            var consulta = _repository.Buscar(id);
            return Redirect("/Consulta/Historico/" + consulta.IdCliente);
        }

        public ActionResult Historico()
        {
            _repository = new ConsultaRepository();

            var idCliente = Url.RequestContext.RouteData.Values["id"];
            var listaConsulta = _repository.GetConsultasPorCliente(Convert.ToInt32(idCliente));

            return View(listaConsulta);
        }

        public ActionResult BuscarCliente(string nome)
        {
            if (!string.IsNullOrEmpty(nome))
            {
                _clienteRepository = new ClienteRepository();

                var clientes = _clienteRepository.BuscarPorNome(nome);

                List<ClienteDiagnosticoViewModel> listVM = new List<ClienteDiagnosticoViewModel>();

                foreach (var cliente in clientes)
                {
                    ClienteDiagnosticoViewModel vm = new ClienteDiagnosticoViewModel();
                    vm.IdCliente = cliente.Id;
                    vm.Nome = cliente.Nome;
                    vm.TemDiagnostico = false;

                    listVM.Add(vm);
                }

                ViewBag.Clientes = listVM;
            }

            return View("Index");
        }

        [HttpPost] //POST: Consulta
        public ActionResult AdicionarConsulta(ConsultaViewModel consultaVm)
        {
            _repository = new ConsultaRepository();
            _procedimentoConsultaRepository = new ProcedimentoConsultaRepository();

            Consulta consulta = new Consulta
            {
                IdCliente = consultaVm.IdCliente,
                Observacao = consultaVm.Observacao
            };

            int idConsulta = _repository.Adicionar(consulta);

            List<ProcedimentoConsulta> listaProcedimentoConsulta = new List<ProcedimentoConsulta>();

            var lista = consultaVm.ListaCheckBoxProcedimento.Where(x => x.Checked == true);

            foreach (var procedimento in lista)
            {
                ProcedimentoConsulta pc = new ProcedimentoConsulta();
                pc.IdProcedimento = procedimento.Id;
                pc.IdConsulta = idConsulta;

                listaProcedimentoConsulta.Add(pc);
            }

            _procedimentoConsultaRepository.Adicionar(listaProcedimentoConsulta);

            return RedirectToAction("Index");
        }

    }
}