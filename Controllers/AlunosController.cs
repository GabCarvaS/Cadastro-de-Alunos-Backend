using AlunosApi.Interfaces;
using AlunosApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlunosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Produces("application/json")]
    public class AlunosController : ControllerBase
    {
        private IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAllAlunos()
        {
            try
            {
                var alunos = await _alunoService.GetAllAlunos();
                return Ok(alunos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter alunos ");
            }
        }

        [HttpGet("{id:int}", Name = "GetAlunoById")]
        public async Task<ActionResult<Aluno>> GetAlunoById(int id)
        {
            try
            {
                var aluno = await _alunoService.GetAlunoById(id);
                if (aluno == null)
                {
                    return NotFound($"Aluno com Id = {id} não encontrado");
                }
                return Ok(aluno);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Request inválido");
            }
        }

        [HttpGet("GetAlunoByNome")]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunoByNome([FromQuery] string nome)
        {
            try
            {
                var alunos = await _alunoService.GetAlunoByNome(nome);
                if (alunos == null)
                {
                    return NotFound($"Não existem alunos com o critério {nome}");
                }
                return Ok(alunos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Request inválido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateAluno([FromBody] Aluno aluno)
        {
            try
            {
                await _alunoService.CreateAluno(aluno);
                return CreatedAtRoute(nameof(GetAlunoById), new { id = aluno.Id }, aluno);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Request inválido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateAluno(int id, [FromBody] Aluno aluno)
        {
            try
            {
                if (id == aluno.Id)
                {
                    await _alunoService.UpdateAluno(aluno);
                    //return NoContent();
                    return Ok($"Aluno com id={id} foi atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Dados inválidos para atualização do aluno");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Request inválido");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAluno(int id)
        {
            try
            {
                var aluno = await _alunoService.GetAlunoById(id);
                if(aluno != null)
                {
                    await _alunoService.DeleteAluno(aluno);
                    return Ok($"Aluno com id={id} foi excluido com sucesso");
                }
                else
                {
                    return NotFound($"Aluno com id={id} não encontrado");
                }
                
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Request inválido");
            }
        }
    }
}
