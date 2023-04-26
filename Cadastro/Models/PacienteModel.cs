namespace Cadastro.Models
{
    public class PacienteModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Diagnostico { get; set; }
        public DateTime DtNascimento { get; set; }
        public DateTime DtEntrada { get; set; }
        public string Status { get; set; } 

    }
}
