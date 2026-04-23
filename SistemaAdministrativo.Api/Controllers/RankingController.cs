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
        public async Task<ActionResult<List<RankingModel>>> GetTodos()
        {
            var resultado = await _rankingServices.ObterTodos();
            return Ok(resultado);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RankingModel>> GetPorId(Guid id)
        {
            var resultado = await _rankingServices.ObterPorId(id);
            if (resultado == null) return NotFound(new { message = "Ranking não encontrado." });

            return Ok(resultado);
        }

        [HttpGet("aluno/{alunoId:guid}")]
        public async Task<ActionResult<RankingModel>> GetPorAluno(Guid alunoId)
        {
            var resultado = await _rankingServices.ObterPorAluno(alunoId);
            if (resultado == null) return NotFound(new { message = "Ranking para este aluno não encontrado." });

            return Ok(resultado);
        }

        [HttpGet("turma/{turmaId:guid}")]
        public async Task<ActionResult<List<RankingModel>>> GetRankingDaTurma(Guid turmaId)
        {
            var resultado = await _rankingServices.ObterRankingDaTurma(turmaId);
            return Ok(resultado);
        }

        [HttpPost("gerar-ranking-turma/{turmaId:guid}")]
        public async Task<IActionResult> CriarRankingTurma(Guid turmaId)
        {
            var sucesso = await _rankingServices.CrearRanking(turmaId);
            if (!sucesso) return BadRequest(new { message = "Não foi possível gerar o ranking (Turma vazia ou erro na operação)." });

            return Ok(new { message = "Ranking gerado com sucesso para os alunos da turma." });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> AtualizarRanking(Guid id, [FromBody] RakingAdicionarAtualizarModel model)
        {
            var sucesso = await _rankingServices.AtulizarRaking(id, model);
            if (!sucesso) return BadRequest(new { message = "Erro ao atualizar os pontos do ranking." });

            return Ok(new { message = "Atualizado com Sucesso!" });
        }

        [HttpDelete("{turmaId:guid}")]
        public async Task<IActionResult> Remover(Guid turmaId)
        {
            await _rankingServices.RemoverRanking(turmaId);
            return Ok(new { message = "Removido com Sucesso!" });
        }
    }
}
