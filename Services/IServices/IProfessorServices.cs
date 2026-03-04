using Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.IServices
{
    public interface IProfessorServices
    {
        Task<bool> CrearProfessor(AdicionarAtualizaProfessorModel model);
        Task<bool> AtulizarProfessor(AdicionarAtualizaProfessorModel model);

        Task<ProfessorModel> ObterPorId(Guid id);
        Task<List<ProfessorModel>> ObterTodos();

        Task RemoverProfessor(Guid id);
    }
}
