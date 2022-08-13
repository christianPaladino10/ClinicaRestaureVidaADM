using AdminRestaureVida.Models;
using AdminRestaureVida.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminRestaureVida.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteRepository _repository;
        private DiagnosticoRepository _repositoryDiagnostico;
        private ConsultaRepository _repositoryConsulta;
        private ProcedimentoConsultaRepository _repositoryProcedimentoConsulta;

        // GET: Cliente
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["Autorizado"] != null)
            {
                _repository = new ClienteRepository();

                var clientes = _repository.BuscarTodos();
                return View(clientes);
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

        [HttpPost] //POST: Cliente
        public ActionResult AdicionarCliente(Cliente cliente)
        {
            if (Session["Autorizado"] != null)
            {
                _repository = new ClienteRepository();

                _repository.Adicionar(cliente);

                //ViewBag.Mensagem = "Cadastro Efetuado com Sucesso!";
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
                _repository = new ClienteRepository();
                var clienteEscolhido = _repository.Buscar(id);

                if (clienteEscolhido.DataNascimento == DateTime.MinValue)
                    clienteEscolhido.DataNascimento = null;

                if (clienteEscolhido.DataNascimentoMae == DateTime.MinValue)
                    clienteEscolhido.DataNascimentoMae = null;

                if (clienteEscolhido.DataNascimentoPai == DateTime.MinValue)
                    clienteEscolhido.DataNascimentoPai = null;

                return View(clienteEscolhido);
            }
            else
                return RedirectToAction("Index", "Login");
        }

        [HttpPost] //POST (enviar)
        public ActionResult EditarCliente(Cliente cliente)
        {
            if (Session["Autorizado"] != null)
            {
                _repository = new ClienteRepository();
                _repository.Alterar(cliente);

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
                _repositoryDiagnostico = new DiagnosticoRepository();
                _repositoryDiagnostico.DeletarPorCliente(id);

                _repositoryProcedimentoConsulta = new ProcedimentoConsultaRepository();
                _repositoryProcedimentoConsulta.DeletarPorCliente(id);

                _repositoryConsulta = new ConsultaRepository();
                _repositoryConsulta.DeletarPorCliente(id);

                _repository = new ClienteRepository();
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
                _repository = new ClienteRepository();
                var clienteEscolhido = _repository.Buscar(id);
                return View(clienteEscolhido);
            }
            else
                return RedirectToAction("Index", "Login");
        }

    }
}