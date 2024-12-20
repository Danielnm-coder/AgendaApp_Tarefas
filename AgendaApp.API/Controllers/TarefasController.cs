
using AgendaApp.Domain.Dtos.Requests;
using AgendaApp.Domain.Dtos.Responses;
using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApp.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly  ITarefaDomainService _tarefaDomainService;

        public TarefasController(ITarefaDomainService tarefaDomainService)
        {
            _tarefaDomainService = tarefaDomainService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TarefaResponse), 201)]
        public IActionResult Post(TarefaRequest request)
        {
            try
            {
                var pessoaId = Guid.Parse(User.Identity.Name);

                var reponse = _tarefaDomainService.Criar(request, pessoaId);

                return StatusCode(201, reponse);
            }
            catch(ValidationException e) 
            {
                return StatusCode(400, new { erros = e.Errors.Select(e => e.ErrorMessage) });
            }
            catch (Exception e)
            {
                return StatusCode(500, new {e.Message});
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TarefaResponse),200)]
        public IActionResult Put(Guid id,[FromBody] TarefaRequest  request)
        {
            try
            {
                var pessoaId = Guid.Parse(User.Identity.Name);


                var response = _tarefaDomainService.Alterar(id, request, pessoaId);

                return StatusCode(200,response);
            }
            catch (ValidationException e)
            {
                return StatusCode(400, new {erros = e.Errors.Select(e => e.ErrorMessage)});
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TarefaResponse), 200)]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                var pessoaId = Guid.Parse(User.Identity.Name);

                var response = _tarefaDomainService.Excluir(Id, pessoaId);
                return StatusCode(200, response);
            }
            catch(ApplicationException e)
            {
                return StatusCode(422, new {e.Message});
            }
            catch(Exception e)
            {
                return StatusCode(500, new{e.Message});
            }

        }

        [HttpGet("{dataMin}/{dataFim}")]
        [ProducesResponseType(typeof(TarefaResponse), 200)]
        public IActionResult GetAll(DateTime dataMin, DateTime dataFim)
        {
            try
            {
                //capturar o ID contido no TOKEN JWT
                var pessoaId = Guid.Parse(User.Identity.Name);

                //excluir a tarefa no dominio
                var response = _tarefaDomainService.Consultar(dataMin, dataFim, pessoaId);
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TarefaResponse), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                //capturar o ID contido no TOKEN JWT
                var pessoaId = Guid.Parse(User.Identity.Name);

                //obter a tarefa no dominio pelo id
                var response = _tarefaDomainService.Obter(id, pessoaId);
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }
    }
}

