using Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.IServices
{
    public interface IRankingServices
    {
        Task<bool> CrearRanking(Guid TurmaId);
        Task<bool> AtulizarRaking(Guid id, RakingAdicionarAtualizarModel model);

        Task<RankingModel> ObterPorId(Guid id);
        Task<List<RakingAdicionarAtualizarModel>> ObterTodos();

        Task<RankingModel> ObterPorAluno(Guid alunoId);

        Task<List<RankingModel>> ObterRankingDaTurma( Guid turmaid);

        Task RemoverRanking(Guid turmaId);
    }
}
