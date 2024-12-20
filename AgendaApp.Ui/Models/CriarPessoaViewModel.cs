using System.ComponentModel.DataAnnotations;

namespace AgendaApp.UI.Models
{
    /// <summary>
    /// Modelo de dados para o formulário da página de criação de pessoa
    /// </summary>
    public class CriarPessoaViewModel
    {
        [MinLength(8, ErrorMessage = "Por favor, informe o nome com pelo menos {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome.")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email.")]
        public string? Email { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Por favor, informe a senha com letras maiúsculas, minúsculas, números, símbolos e pelo menos 8 caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a senha.")]
        public string? Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Senhas não conferem, por favor verifique.")]
        [Required(ErrorMessage = "Por favor, confirme a senha.")]
        public string? SenhaConfirmacao { get; set; }
    }
}



