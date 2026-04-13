using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using Services.Model;

namespace SistemaAdministrativo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        private readonly IRankingServices _rankingServices;

        public RankingController(IRankingServices rankingServices)
        {
            _rankingServices = rankingServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<RakingAdicionarAtualizarModel>>> GetTodos()
        {
            var resultado = await _rankingServices.ObterTodos();
            return Ok(resultado);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RakingAdicionarAtualizarModel>> GetPorId(Guid id)
        {
            var resultado = await _rankingServices.ObterPorId(id);
            if (resultado == null) return NotFound("Ranking não encontrado.");

            return Ok(resultado);
        }

        [HttpGet("aluno/{alunoId:guid}")]
        public async Task<ActionResult<RakingAdicionarAtualizarModel>> GetPorAluno(Guid alunoId)
        {
            var resultado = await _rankingServices.ObterPorAluno(alunoId);
            if (resultado == null) return NotFound("Ranking para este aluno não encontrado.");

            return Ok(resultado);
        }

        [HttpGet("turma/{turmaId:guid}")]
        public async Task<ActionResult<List<RakingAdicionarAtualizarModel>>> GetRankingDaTurma(Guid turmaId)
        {
            var resultado = await _rankingServices.ObterRankingDaTurma(turmaId);
            return Ok(resultado);
        }

        [HttpPost("gerar-ranking-turma/{turmaId:guid}")]
        public async Task<IActionResult> CriarRankingTurma(Guid turmaId)
        {
            var sucesso = await _rankingServices.CrearRanking(turmaId);
            if (!sucesso) return BadRequest("Não foi possível gerar o ranking (Turma vazia ou erro na operação).");

            return Ok("Ranking gerado com sucesso para os alunos da turma.");
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> AtualizarRanking(Guid id, [FromBody] RakingAdicionarAtualizarModel model)
        {
            var sucesso = await _rankingServices.AtulizarRaking(id, model);
            if (!sucesso) return BadRequest("Erro ao atualizar os pontos do ranking.");

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            await _rankingServices.RemoverRanking(id);
            return NoContent();
        }
    }
}
