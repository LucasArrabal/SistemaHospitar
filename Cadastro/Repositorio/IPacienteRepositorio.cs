using Cadastro.Models;

namespace Cadastro.Repositorio
{
    public interface IPacienteRepositorio
    {
        Paciente ListarPorId(int id);
        List<Paciente> BuscarTodos();
        Paciente Adicionar(Paciente paciente);
        Paciente Atualizar(Paciente paciente);
        bool Deletar(int id);
    }
}
