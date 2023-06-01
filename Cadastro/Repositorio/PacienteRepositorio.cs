using Cadastro.Data;
using Cadastro.Models;

namespace Cadastro.Repositorio
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly CadastroContext _bdContext;
        public PacienteRepositorio(CadastroContext bdContext)
        {
            _bdContext = bdContext;
        }

        public Paciente ListarPorId(int id)
        {
            return _bdContext.Paciente.FirstOrDefault(x => x.Id == id);
        }

        public List<Paciente> BuscarTodos()
        {
            return _bdContext.Paciente.ToList();
        }
        public Paciente Adicionar(Paciente paciente)
        {
            _bdContext.Paciente.Add(paciente);
            _bdContext.SaveChanges();
            return paciente;
        }

        public Paciente Atualizar(Paciente paciente)
        {
            Paciente pacienteBd = ListarPorId(paciente.Id);

            if(pacienteBd == null)
            {
                throw new Exception("houve um erro na atualizaçao do paciente");
            }
            pacienteBd.Name = paciente.Name;
            pacienteBd.DtEntrada = paciente.DtEntrada;
            pacienteBd.Status = paciente.Status;
            pacienteBd.Diagnostico = paciente.Diagnostico;
            paciente.DtNascimento = paciente.DtNascimento;

            _bdContext.Paciente.Update(pacienteBd);
            _bdContext.SaveChanges();

            return pacienteBd;
        }

        public bool Deletar(int id)
        {
            Paciente pacienteBd = ListarPorId(id);

            if (pacienteBd == null)
            {
                throw new Exception("houve um erro na hora de apagar o paciente");
            }

            _bdContext.Paciente.Remove(pacienteBd);
            _bdContext.SaveChanges();

            return true;
        }
    }
}
