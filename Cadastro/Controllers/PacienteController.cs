using Cadastro.Models;
using Cadastro.Repositorio;
using Microsoft.AspNetCore.Mvc;

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
            _pacienteRepositorio.Deletar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(Paciente paciente)
        {
            _pacienteRepositorio.Adicionar(paciente);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Alterar(Paciente paciente)
        {
            _pacienteRepositorio.Atualizar(paciente);
            return RedirectToAction("Index");
        }

    }
}
