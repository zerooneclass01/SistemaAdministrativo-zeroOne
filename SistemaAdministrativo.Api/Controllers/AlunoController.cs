using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using Services.Model;

namespace SistemaAdministrativo.Api.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class AlunoController : Controller
    {
        private readonly IAlunoServices _alunoServices;

        public AlunoController(IAlunoServices alunoServices)
        {
            _alunoServices = alunoServices;
        }

       
        [HttpGet("ObterTodos")]
        public async Task<ActionResult<IEnumerable<AlunoModel>>> ObterAlunos()
        {
           var resultado = await _alunoServices.ObterTodos();

            return Ok(resultado);
        }

        
        [HttpGet("ObterAluno/{id:guid}")]
        public async Task<ActionResult<AlunoModel>> ObterPorId(Guid id)
        {
            var resultado = await _alunoServices.ObterPorId(id);

            return Ok(resultado);
        }


       
        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] AlunoCriarModel model)
        {
            var salvo = await _alunoServices.CrearAluno(model);
            if (!salvo)
                return BadRequest("Erro ao Cadastrar Aluno.");

            return Ok(salvo);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Autalizar(Guid id,[FromBody] AlunoAtualizarModel model)
        {
            var salvo = await _alunoServices.AtulizarAluno(id,model);
            if (!salvo)
                return BadRequest("Erro ao Atualizar Aluno.");

            return Ok(salvo);
        }

     
        [HttpDelete("Remover/{id:guid}")]
        public async Task<IActionResult>Remover(Guid id)
        {
            var salvo = _alunoServices.RemoverAluno(id);
            
            if (salvo.IsCanceled)
                return BadRequest("Ocorreu um erro na execução");

            return Ok("Removido Com Sucesso!");
        }

        [HttpPut("altera-Turma/{alunoid:guid}/{turmaid:guid}")]
        public async Task<IActionResult> AlteraTurma(Guid alunoid, Guid turmaid)
        {
            var salvo = await _alunoServices.AlteraTurmaAluno(alunoid, turmaid);
            if (!salvo)
                return BadRequest("Ocorreu um erro na execução");

            return Ok("Altera Turma Com Sucesso!");
        }

        [HttpPost("VinculaTurmaAluno/{alunoid:guid}/{turmaid:guid}")]
        public async Task<IActionResult> VincularAlunoTurma(Guid alunoid, Guid turmaid) 
        { 
            var salvo = await _alunoServices.VinncularUmaTurma(alunoid,turmaid);

            if(!salvo)
                return BadRequest(new { message ="Ocorreu um erro na execução" });

            return Ok(new { message= "Vinculado Com Sucesso!" });
        }

        [HttpPatch("Ativa/{Alunoid:guid}")]
        public async Task<IActionResult> AtivarAluno(Guid Alunoid, [FromBody] bool status)
        {
            var salvo = await _alunoServices.AtivarouDesativaAluno(Alunoid,status);

            if(!salvo)
                return BadRequest(new { message = "Ocorreu um erro na execução" });

            return Ok(new { message = "Status Alterado Com Sucesso!" });

        }
    }
}
