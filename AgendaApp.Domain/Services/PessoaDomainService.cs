using AgendaApp.Domain.Dtos.Requests;
using AgendaApp.Domain.Dtos.Responses;
using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Helpers;
using AgendaApp.Domain.Interfaces.Messages;
using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Domain.Interfaces.Security;
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
    public class PessoaDomainService : IPessoaDomainService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMessageProducer _messageProducer;
        private readonly ITokenSecurity _tokenSecurity;

        public PessoaDomainService(IPessoaRepository pessoaRepository, IMessageProducer messageProducer, ITokenSecurity tokenSecurity)
        {
            _pessoaRepository = pessoaRepository;
            _messageProducer = messageProducer;
            _tokenSecurity = tokenSecurity;
        }

        public CriarPessoaResponse Criar(CriarPessoaRequest request)
        {
            #region Capturar e validar os dados de pessoa

            var pessoa = new Pessoa
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Email = request.Email,
                Senha = request.Senha
            };

            var validator = new PessoaValidator();
            var result = validator.Validate(pessoa);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            #endregion

            #region Verificar se já existe uma pessoa com o mesmo email cadastrado

            if (_pessoaRepository.VerifyExists(pessoa.Email))
                throw new ApplicationException("O email informado já está cadastrado. Tente outro.");

            #endregion

            #region Criptografar a senha e gravar pessoa no banco de dados

            pessoa.Senha = SHA256Helper.Encrypt(request.Senha);
            _pessoaRepository.Add(pessoa);

            #endregion

            #region Enviar os dados para uma mensageria

            var response = new CriarPessoaResponse
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Email = pessoa.Email,
                DataHoraCadastro = DateTime.Now
            };

            _messageProducer.Send(response);

            #endregion

            #region Retornar os dados de resposta

            return response;

            #endregion
        }

        public AutenticarPessoaResponse Autenticar(AutenticarPessoaRequest request)
        {
            #region Pesquisar A pessoa no banco de dados atravez do emial e da senha 


            var pessoa =_pessoaRepository.Get(request.Email, SHA256Helper.Encrypt(request.Senha));

            if (pessoa == null)
                throw new ApplicationException("Acesso negado.Pessoa não encontrada ");

            #endregion

            #region Gerar o token e retornar a pessoa 

            var response = new AutenticarPessoaResponse
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Email = pessoa.Email,
                DataHoraAcesso = DateTime.Now,
                DataHoraExpiracao = _tokenSecurity.GetExpirationDate(),
                Token = _tokenSecurity.CreateToken(pessoa.Id)
            };

            return response;

            #endregion
        }
    }
}



