using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using Services.Model;

namespace SistemaAdministrativo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChamadaController : ControllerBase
    {
        private readonly IChamadaServices _chamadaService;

        public ChamadaController(IChamadaServices chamadaService)
        {
            _chamadaService = chamadaService;
        }

        [HttpPost] 
        public async Task<IActionResult> Registrar(AdicionarChamadaModel model)
        {
            if (model == null) return BadRequest("Dados inválidos.");

            var sucesso = await _chamadaService.Registrar(model);

            if (!sucesso)
                return BadRequest("Erro ao registrar a chamada.");

            return Ok("Chamada registrada com sucesso!");
        }

        [HttpPatch("{id:guid}/presencas")] 
        public async Task<IActionResult> AlterarPresenca(Guid id, List<AlunoPresencaModel> alunos)
        {
            if (alunos == null || !alunos.Any())
                return BadRequest("A lista de alunos não pode estar vazia.");

            var sucesso = await _chamadaService.AlterarPresenca(id, alunos);

            if (!sucesso)
                return NotFound("Chamada não encontrada ou sem itens para atualizar.");

            return Ok("Presenças atualizadas com sucesso!");
        }

        [HttpGet("{id:guid}")] 
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var resultado = await _chamadaService.ObterPorId(id);

            if (resultado == null)
                return NotFound("Chamada não encontrada.");

            return Ok(resultado);
        }

        [HttpGet("turma/{turmaId:guid}")] 
        public async Task<IActionResult> ObterPorTurma(Guid turmaId)
        {
            var resultado = await _chamadaService.ObterPorTurma(turmaId);

            if (resultado == null || !resultado.Any())
                return NotFound("Nenhuma chamada encontrada para esta turma.");

            return Ok(resultado);
        }
    }
}