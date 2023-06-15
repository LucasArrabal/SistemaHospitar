using Cadastro.Models;
using Cadastro.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cadastro.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IPacienteRepositorio _pacienteRepositorio;
        public PacienteController(IPacienteRepositorio pacienteRepositorio)
        {
            _pacienteRepositorio = pacienteRepositorio;
        }
        public IActionResult Index()
        {
            List<Paciente> pacientes = _pacienteRepositorio.BuscarTodos();
            return View(pacientes);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            Paciente paciente = _pacienteRepositorio.ListarPorId(id);
            return View(paciente);
        }
        public IActionResult Apagar(int id)
        {
            Paciente paciente = _pacienteRepositorio.ListarPorId(id);
            return View(paciente);
        }
        public IActionResult Deletar(int id)
        {
            try
            {
               bool apagado =  _pacienteRepositorio.Deletar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Criar(Paciente paciente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pacienteRepositorio.Adicionar(paciente);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(paciente);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
               
            }

        }
        [HttpPost]
        public IActionResult Alterar(Paciente paciente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pacienteRepositorio.Adicionar(paciente);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Index", paciente);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos alterar, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
