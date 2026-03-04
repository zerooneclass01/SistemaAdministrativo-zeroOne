using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositorio.IRepository;
using Services.IServices;
using Services.Model;

namespace SistemaAdministrativo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServices _usuarioService;

        public UsuarioController(IUsuarioServices usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [Authorize(Roles = "Admin,RH")]
        [HttpPost("Criar-Usuario")]
        public async Task<IActionResult> CriarUsuario(CriarUsuarioRequest usuario)
        {
            var criandoUsuario = await _usuarioService.Cadastrar(usuario);

            if(!criandoUsuario)
                return NotFound("Correu um problema, Tente novamente ou Liga para Suporte.");

            return Ok("Usuario criado com Sucesso!");
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest usuario)
        {
            var token = await _usuarioService.Login(usuario);

            return token != null ? Ok(new { token }) : Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost ("esqueci-senha")]
        public async Task<IActionResult> EsqueciSenha([FromBody] string email)
        {
            var resultado = await _usuarioService.EsqueciSenha(email);

            return Ok("Se o usuário existir, o e-mail foi enviado.");
        }

        [AllowAnonymous]
        [HttpPost("resetar-senha")]
        public async Task<IActionResult>ResetarSenha(ResetSenhaRequest usuario)
        {
            var successea = await _usuarioService.ResetarSenha(usuario);
            return successea ? Ok("Senha Alterada !") : BadRequest("Erro ao resetar.");
        }


    }
}
