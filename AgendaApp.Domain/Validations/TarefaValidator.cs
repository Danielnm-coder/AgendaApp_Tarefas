using AgendaApp.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Validations
{
    public class TarefaValidator : AbstractValidator<Tarefa>
    {
        public TarefaValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("Informe o ID da tarefa.");

            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Informe o nome da tarefa.")
                .Length(8, 150).WithMessage("Informe o nome da tarefa de 8 a 150 caracteres.");

            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("Informe a descrição da tarefa.")
                .Length(8, 250).WithMessage("Informe a descrição da tarefa de 8 a 250 caracteres.");

            RuleFor(p => p.DataHora)
                .NotNull().WithMessage("Informe a data e hora da tarefa.");

            RuleFor(p => p.Prioridade)
                .NotNull().WithMessage("Informe a prioridade da tarefa.");

            RuleFor(p => p.PessoaId)
                .NotEmpty().WithMessage("Informe o ID da pessoa para esta tarefa.");
        }
    }
}
