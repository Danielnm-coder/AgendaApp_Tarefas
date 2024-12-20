using AgendaApp.Domain.Dtos.Requests;
using AgendaApp.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Interfaces.Services
{
    public interface ITarefaDomainService
    {
        TarefaResponse Criar(TarefaRequest request, Guid pessoaId);

        TarefaResponse Alterar(Guid tarefaId, TarefaRequest request, Guid pessoaId);

        TarefaResponse Excluir(Guid tarefaId, Guid pessoaId);

        List <TarefaResponse> Consultar(DateTime dataMin, DateTime dataFim, Guid pessoaId);

        TarefaResponse Obter(Guid tarefaId, Guid pessoaId);
    }
}
