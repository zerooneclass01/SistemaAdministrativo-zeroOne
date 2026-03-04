using Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.IServices
{
    public interface IMensalidadeServices
    {
        Task<MensalidadeModel> ObterPorId(Guid id);

        Task<IEnumerable<MensalidadeModel>> ObterTodos();
        Task<IEnumerable<MensalidadeModel>> ListarPorAluno(Guid alunoId);
        Task<IEnumerable<MensalidadeModel>> ListarVencidas();

        Task<MensalidadeAtualizarAdicionarModel> GerarMensalidade(Guid alunoId, decimal valor, DateTime vencimento);

        Task MudarStatusPagamento(Guid id, int novoStatus);

        Task ProrrogarVencimento(Guid id, DateTime novaData);

        Task<bool> ExcluirMensalidade(Guid id);
    }
}
