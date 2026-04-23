using Dominio.Entidades;
using Repositorio.IRepository.IRepositoryBase;
using Services.IServices;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Services.Services
{
    public class RankingServices : IRankingServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public RankingServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AtulizarRaking(Guid id, RakingAdicionarAtualizarModel model)
        {
            if(model == null && id == Guid.Empty)
                return false;

            var obterRanking = await _unitOfWork.Ranking.ObterPorId(id);

            obterRanking.AtualizarPontos(model.Pontos);

            _unitOfWork.Ranking.Atualizar(obterRanking);

            var salvo = await _unitOfWork.CompleteAsync() > 0;
            await _unitOfWork.CommitTransactionAsync();

            return salvo;
        }

        public async Task<bool> CrearRanking(Guid TurmaId)
        {
            if (TurmaId == Guid.Empty)
                return false;

            var obterAlunos =  await _unitOfWork.AlunoTurma.ListarAlunosPorTurma(TurmaId);
            if (obterAlunos == null || !obterAlunos.Any())
                return false;


            foreach ( var aluno in obterAlunos)
            {
                var existeUmRaking = await _unitOfWork.Ranking.ObterPorAluno(aluno.Id);

                if(existeUmRaking == null)
                {
                    var novoRanking = new Ranking();
                    novoRanking.AdicionarAluno(TurmaId, aluno.Id, 0);

                    await _unitOfWork.Ranking.Adicionar(novoRanking);
                }

            }

            var salvo = await _unitOfWork.CompleteAsync() > 0;
            await _unitOfWork.CommitTransactionAsync();
            return salvo;
        }

        public async Task<RankingModel> ObterPorAluno(Guid alunoId)
        {
            var resultado = await _unitOfWork.Ranking.ObterPorAluno(alunoId);

            if (resultado == null) return null;

            return new RankingModel
            {
                Id = resultado.Id,
                Alunoid = resultado.Alunoid,
                Turmaid = resultado.Turmaid,
                Pontos = resultado.Pontos
            };
        }

        public async Task<RankingModel> ObterPorId(Guid id)
        {
            var resultado = await _unitOfWork.Ranking.ObterPorId(id);

            if (resultado == null) return null;

            return new RankingModel
            {
                Id = resultado.Id,
                Alunoid = resultado.Alunoid,
                Turmaid = resultado.Turmaid,
                Pontos = resultado.Pontos
            };
        }

        public async Task<List<RankingModel>> ObterRankingDaTurma(Guid turmaid)
        {
            var listaRanking = await _unitOfWork.Ranking.ObterPorTurma(turmaid);

            return listaRanking.Select(r => new RankingModel
            {
                Id = r.Id,  
                Alunoid = r.Alunoid,
                Turmaid = r.Turmaid,
                Pontos = r.Pontos
            }).ToList();
        }

        public async Task<List<RakingAdicionarAtualizarModel>> ObterTodos()
        {
            var listaRanking = await _unitOfWork.Ranking.ObterTodos();

            return listaRanking.Select(r => new RakingAdicionarAtualizarModel
            {
                Alunoid = r.Alunoid,
                Turmaid = r.Turmaid,
                Pontos = r.Pontos
            }).ToList();
        }

        public async Task RemoverRanking(Guid turmaId)
        {
            var rankingsDaTurma = await _unitOfWork.Ranking.ObterPorTurma(turmaId);

            if (rankingsDaTurma == null || !rankingsDaTurma.Any()) return;

            foreach (var item in rankingsDaTurma)
            {
                _unitOfWork.Ranking.Remover(item.Id);
            }

            await _unitOfWork.CommitTransactionAsync(); ;
            
        }
    }
}
