using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using Services.Model;

namespace SistemaAdministrativo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoricoAlunoController : Controller
    {
        private readonly IHistoricoAlunoServices _services;

        public HistoricoAlunoController(IHistoricoAlunoServices services)
        {
            _services = services;
        }

        [HttpPost("AdicionarHistorico")]
        public async Task<IActionResult> AdicionarHistorico([FromBody] HistoricoAlunoAdicionarModel model)
        {
            var salvo = await _services.AdicionarHistorico(model);

            if (!salvo)
                return BadRequest(new { mensagem = "Não foi possível salvar o histórico." });

            return Ok(new { mensagem = "Histórico adicionado com sucesso!", sucesso = true });
        }

        [HttpPut("{idHistorico:guid}")]
        public async Task<IActionResult> AtualizarHistorico([FromBody] HistoricoAtualizarModel model, Guid idHistorico)
        {
            var salvo = await _services.AtualizarHistorico(model, idHistorico);

            if (!salvo)
                return BadRequest(new { mensagem = "Não foi possìvel Atualizar o histórico." });

            return Ok(new { mensagem = "Histórico Atualizado com sucesso!", sucesso = true });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoricoAlunoModel>>> ObterHistoricos()
        {
            var resultado = await _services.Historicos();

            return Ok(resultado);
        }

        [HttpGet("HistoricosDoAluno/{alunoId:guid}")]
        public async Task<ActionResult<IEnumerable<HistoricoAlunoModel>>> HistoricosDoAluno(Guid alunoId)
        {
            var resultado = await _services.HistoricosDoAluno(alunoId);

            return Ok(resultado);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult>ObterHistoricoId(Guid id)
        {
            var resultado = await _services.ObterPorId(id);

            return Ok(resultado);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> RemoverHistorico(Guid id)
        {
            var salvo = await _services.RemoverHistorico(id);
            
            if(!salvo)
                return BadRequest(new { mensagem = "Não foi possìvel remover o histórico." });

            return Ok(new {mensagem ="Histórico removido com sucesso.",sucesso = true});
        }
    }
}
