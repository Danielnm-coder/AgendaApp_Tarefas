using System.ComponentModel.DataAnnotations;

namespace AgendaApp.Ui.Models
{
    /// <summary>
    /// Modelo de dados para o formulário da página de autenticação de pessoa
    /// </summary>
    public class AutenticarPessoaViewModel
    {
        [EmailAddress(ErrorMessage = "Por favor , informe um endereço de email valido.")]
        [Required(ErrorMessage = "Por favor , informe o email")]
        public string? Email { get; set; }

        [MinLength(8,ErrorMessage = "Por favor , infdorme no minimo {1} caracteres ")]
        [Required(ErrorMessage = "Por favor , informe a senha")]
        public  string? Senha { get; set; }
    }
}
