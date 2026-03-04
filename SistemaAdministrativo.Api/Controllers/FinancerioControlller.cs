using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using Services.Model;
using Services.Services;
using System;
using System.Threading.Tasks;

namespace SistemaAdministrativo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinanceiroController : ControllerBase
    {
        private readonly IFinanceiroServices _financeiroService;

        public FinanceiroController(IFinanceiroServices financeiroService)
        {
            _financeiroService = financeiroService;
        }

        [HttpGet("balancete")]
        public async Task<ActionResult<BalanceteModel>> GetBalancete([FromQuery] int mes, [FromQuery] int ano)
        {
            var balancete = await _financeiroService.GerarBalancete(mes, ano);
            return Ok(balancete);
        }

        [HttpPost("despesa")]
        public async Task<IActionResult> CriarDespesa(DespesaModel model)
        {
            var sucesso = await _financeiroService.RegistrarDespesa(model);
            if (!sucesso) return BadRequest();
            return Ok();
        }

        [HttpPatch("mensalidade/{id:guid}/pagar")]
        public async Task<IActionResult> PagarMensalidade(Guid id)
        {
            var sucesso = await _financeiroService.BaixarMensalidade(id);
            if (!sucesso) return BadRequest();
            return Ok();
        }
    }
}