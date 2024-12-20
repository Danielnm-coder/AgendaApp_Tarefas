using System.ComponentModel.DataAnnotations;

namespace AgendaApp.UI.Models
{
    public class CadastrarTarefaViewModel
    {
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome da tarefa.")]
        public string? Nome { get; set; }

        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a descrição da tarefa.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data e hora da tarefa.")]
        public string? DataHora { get; set; }

        [Required(ErrorMessage = "Por favor, informe a prioridade da tarefa.")]
        public string? Prioridade { get; set; }
    }
}



