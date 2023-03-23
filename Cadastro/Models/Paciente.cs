namespace Cadastro.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Diagnostico { get; set; }
        public DateTime Dt_Nascimento { get; set; }
        public DateTime Dt_Entrada  { get; set; }
        public string Status { get; set; }

    }
}