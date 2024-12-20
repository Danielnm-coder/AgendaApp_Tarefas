using AgendaApp.Domain.Dtos.Requests;
using AgendaApp.Domain.Dtos.Responses;
using AgendaApp.Domain.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApp.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaDomainService _pessoaDomainService;

        public PessoasController(IPessoaDomainService pessoaDomainService)
        {
            _pessoaDomainService = pessoaDomainService;
        }

        [HttpPost("autenticar")]
        [ProducesResponseType(typeof(AutenticarPessoaResponse), 200)]
        public IActionResult Autenticar(AutenticarPessoaRequest request)
        {
            try
            {
                //HTTP 200 (OK)
                return StatusCode(201, _pessoaDomainService.Autenticar(request));
            }
            catch (ApplicationException e)
            {
                //HTTP 422 (UNPROCESSABLE CONTENT/ENTITY)
                return StatusCode(401, new { message = e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { message = e.Message });
            }
        }


        [HttpPost("criar")]
        [ProducesResponseType(typeof(CriarPessoaResponse), 201)]
        public IActionResult Criar(CriarPessoaRequest request)
        {
            try
            {
                //HTTP 201 (CREATED)
                return StatusCode(201, _pessoaDomainService.Criar(request));
            }
            catch(ValidationException e)
            {
                //HTTP 400 (BAD REQUEST)
                return StatusCode(400, new { errors = e.Errors.Select(e => e.ErrorMessage) });
            }
            catch(ApplicationException e)
            {
                //HTTP 422 (UNPROCESSABLE CONTENT/ENTITY)
                return StatusCode(422, new { message = e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { message = e.Message });
            }
        }

        
    }
}
