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

        Task<RakingAdicionarAtualizarModel> ObterPorId(Guid id);
        Task<List<RakingAdicionarAtualizarModel>> ObterTodos();

        Task<RakingAdicionarAtualizarModel> ObterPorAluno(Guid alunoId);

        Task<List<RakingAdicionarAtualizarModel>> ObterRankingDaTurma( Guid turmaid);

        Task RemoverRanking(Guid id);
    }
}
