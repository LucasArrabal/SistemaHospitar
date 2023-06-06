
using System.ComponentModel.DataAnnotations;

namespace Cadastro.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite seu nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Informe o diagnostico")]
        public string Diagnostico { get; set; }
        [Required(ErrorMessage = "Informe o dia do seu nascimento")]
        public DateTime DtNascimento { get; set; }
        [Required(ErrorMessage = "Informe a data de entrada")]
        public DateTime DtEntrada { get; set; }
        [Required(ErrorMessage = "Informe a situação do paciente")]
        public string Status { get; set; } 

    }
}
