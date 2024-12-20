using AgendaApp.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Validations
{
    public class PessoaValidator : AbstractValidator<Pessoa>
    {
        public PessoaValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Informe o ID da pessoa.");

            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Informe o nome da pessoa.")
                .Length(8, 150).WithMessage("Informe o nome da pessoa de 8 a 150 caracteres.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("Informe o email da pessoa.")
                .EmailAddress().WithMessage("Informe um endereço de email válido.");

            RuleFor(p => p.Senha)
                .NotEmpty().WithMessage("Informe a senha da pessoa.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
                    .WithMessage("A senha deve ter letras maiúsculas, minúsculas, números, símbolos e pelo menos 8 caracteres.");

        }
    }
}
