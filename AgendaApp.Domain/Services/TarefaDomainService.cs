using AgendaApp.Domain.Dtos.Requests;
using AgendaApp.Domain.Dtos.Responses;
using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Domain.Interfaces.Services;
using AgendaApp.Domain.Validations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Services
{
    public class TarefaDomainService : ITarefaDomainService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaDomainService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public TarefaResponse Criar(TarefaRequest request, Guid pessoaId)
        {
            var tarefa = new Tarefa
            {
                Id = Guid.NewGuid(), 
                Nome = request.Nome,
                DataHora = request.DataHora,
                Descricao = request.Descricao,
                Prioridade = (Prioridade)request.Prioridade,
                PessoaId = pessoaId
            };

            var validator  = new TarefaValidator();
            var result = validator.Validate(tarefa);

            if (result.IsValid)
                throw new ValidationException(result.Errors);


            _tarefaRepository.Add(tarefa);

            return GetResponse(tarefa);
        }

        public TarefaResponse Alterar(Guid tarefaId, TarefaRequest request, Guid pessoaId)
        {
            var tarefa = _tarefaRepository.Get(tarefaId,pessoaId);
            if (tarefa == null)
                throw new ApplicationException("Tarefa não encontrada. Verifique o ID informado.");

            tarefa.Nome = request.Nome;
            tarefa.DataHora = request.DataHora;
            tarefa.Descricao = request.Descricao;
            tarefa.Prioridade = (Prioridade)request.Prioridade;


            var validator = new TarefaValidator();
            var result = validator.Validate(tarefa);

            if (result.IsValid)
                throw new ValidationException(result.Errors);

            _tarefaRepository.Update(tarefaId, tarefa);

            return GetResponse(tarefa);
        }

        public TarefaResponse Excluir(Guid tarefaId, Guid pessoaId)
        {
            var tarefa = _tarefaRepository.Get(tarefaId, pessoaId);
            if (tarefa == null)
                throw new ApplicationException("Tarefa não encontrada. Verifique o ID informado.");

            _tarefaRepository.Delete(tarefaId);

            return GetResponse(tarefa);
        }

        public List <TarefaResponse> Consultar(DateTime dataMin, DateTime dataFim, Guid pessoaId)
        {
            var lista = _tarefaRepository.Get(dataMin, dataFim, pessoaId);
            var response = new List<TarefaResponse>();
            foreach ( var item in lista)
            {
                response.Add(GetResponse(item));
            }

            return response;
        }

        public TarefaResponse Obter(Guid tarefaId, Guid pessoaId)
        {
            var tarefa = _tarefaRepository.Get(tarefaId, pessoaId);
            if (tarefa == null)
                throw new ApplicationException("Tarefa não encontrada. Verifique o ID informado.");


            return GetResponse(tarefa);

        }

        private TarefaResponse GetResponse(Tarefa tarefa)
        {
            var response = new TarefaResponse
            {
                Id = tarefa.Id,
                Nome = tarefa.Nome,
                DataHora = tarefa.DataHora,
                Descricao = tarefa.Descricao,
                Prioridade = new PrioridadeResponse
                {
                    Valor = (int)tarefa.Prioridade,
                    Nome = tarefa.Prioridade.ToString()
                }
            };

            return response;
        }
    }
}


