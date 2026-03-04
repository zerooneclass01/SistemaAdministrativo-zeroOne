using Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.IServices
{
    public interface IChamaItemServices
    {
        Task<bool> AtualizarPresencaIndividual(Guid itemId, bool presente, string observacao);
        Task<IEnumerable<ChamadaItemModel>> ObterPresencasPorAluno(Guid alunoId);
    }
}
