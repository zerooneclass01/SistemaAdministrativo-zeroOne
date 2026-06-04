using Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.IServices
{
    public interface IHistoricoAlunoServices
    {

        Task <bool>AdicionarHistorico(HistoricoAlunoAdicionarModel model);
        Task<bool> AtualizarHistorico(HistoricoAtualizarModel model,Guid idHistorico);
        Task<List<HistoricoAlunoModel>> Historicos();
        Task<List<HistoricoAlunoModel>> HistoricosDoAluno(Guid alunoId);
        Task<HistoricoAlunoModel> ObterPorId(Guid id);

        Task<bool> RemoverHistorico(Guid id);

    }
}
