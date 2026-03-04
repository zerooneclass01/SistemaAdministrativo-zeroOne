using BCrypt.Net;
using Dominio.Entidades;
using Microsoft.Extensions.Configuration;
using Repositorio.IRepository;
using Services.IServices;
using Services.Model;
using Services.Services.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository _repository;
        private readonly IConfiguration _config;
        private readonly AuthService _authService;
        private readonly GerarToken  _gerarToken;

        public UsuarioServices(IUsuarioRepository repository, IConfiguration config, AuthService authService,GerarToken gerarToken)
        {
            _repository = repository;
            _config = config;
            _authService = authService;
            _gerarToken = gerarToken;
        }

        public async Task<bool> Cadastrar(CriarUsuarioRequest request)
        {
            var hash = BCrypt.Net.BCrypt.HashPassword(request.Senha);

            var novoUsuario = new Usuario(request.Username, hash,request.Role);

            await _repository.Adicionar(novoUsuario);

            return await _repository.SalvarAlteracoes();
        }

        public async Task<bool> EsqueciSenha(string email)
        {
            var user =  await _repository.ObterPorUsername(email);

            user.GerarTokenRecuperacao();

            _repository.Atualizar(user);

          return await _repository.SalvarAlteracoes();
        }

        public async Task<string?> Login(LoginRequest request)
        {
            var user = await _repository.ObterPorUsername(request.Username);

            if( user == null || !_authService.VerificarSenha(request.Senha,user.SenhaHash))
                return null;

            return _gerarToken.GerarTokenJwt(user);
        }

        public async Task<bool> ResetarSenha(ResetSenhaRequest request)
        {
            var user = await _repository.ObterPorToken(request.Token);

            user.ResetarSenha(request.Senha, request.Token);

             _repository.Atualizar(user);

            return await _repository.SalvarAlteracoes();
        }
    }
}
