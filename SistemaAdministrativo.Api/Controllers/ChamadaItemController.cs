using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using Services.Model;

namespace SistemaAdministrativo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChamadaItemController : ControllerBase
    {
        private readonly IChamaItemServices _itemService;

        public ChamadaItemController(IChamaItemServices itemService)
        {
            _itemService = itemService;
        }

        [HttpPatch("{itemId:guid}")] // PATCH: api/chamadaitem/{guid}
        public async Task<ActionResult> AtualizarPresenca(Guid itemId, PresencaIndividualModel model)
        {
            if (itemId == Guid.Empty) return BadRequest(new { message = "ID do item inválido." });

            var sucesso = await _itemService.AtualizarPresencaIndividual(itemId, model.Presente, model.Observacao);

            if (!sucesso)
                return BadRequest(new { message = "Não foi possível atualizar a presença." });

            return Ok(new { message = "Presença individual atualizada com sucesso!" });
        }

        [HttpGet("aluno/{alunoId:guid}")] // GET: api/chamadaitem/aluno/{guid}
        public async Task<ActionResult<IEnumerable<ChamadaItemModel>>> ListarPorAluno(Guid alunoId)
        {
            if (alunoId == Guid.Empty) return BadRequest(new { message = "ID do aluno inválido." });

            var resultado = await _itemService.ObterPresencasPorAluno(alunoId);

            if (resultado == null || !resultado.Any())
                return NotFound(new { message =  "Nenhum registro de presença encontrado para este aluno."});

            return Ok(resultado);
        }
    }
}