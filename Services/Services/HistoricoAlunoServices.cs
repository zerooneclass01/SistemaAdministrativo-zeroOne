using Dominio.Entidades;
using Repositorio.IRepository.IRepositoryBase;
using Services.IServices;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class HistoricoAlunoServices : IHistoricoAlunoServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public HistoricoAlunoServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AdicionarHistorico(HistoricoAlunoAdicionarModel model)
        {
            var novoHistorico = new HistoricoDoAluno();

            var obterResultadoValidacao = novoHistorico.Adicionar(model.AlunoId, model.ProfessorId, 
                model.StatusComportamento,model.StatusDesempenho, model.Descricao);

            if(obterResultadoValidacao != null)
            {
                throw new ArgumentException(obterResultadoValidacao);
            }

            await _unitOfWork.historicoDoAluno.Adicionar(novoHistorico);

            var salvo =  await _unitOfWork.CompleteAsync() > 0;
            
            await _unitOfWork.CommitTransactionAsync();

            return salvo;
        }

        public async Task<bool> AtualizarHistorico(HistoricoAtualizarModel model, Guid idHistorico)
        {
            var obterHistorico = await _unitOfWork.historicoDoAluno.ObterPorId(idHistorico);

            var obterResultadoValidacao = obterHistorico.Atualizar(model.Descricao,model.StatusComportamento,model.StatusDesempenho);

            if (obterResultadoValidacao != null)
            { 
                throw new ArgumentException(obterResultadoValidacao);
            }
               
            _unitOfWork.historicoDoAluno.Atualizar(obterHistorico);

            var salvo = await _unitOfWork.CompleteAsync() > 0;
            await _unitOfWork.CommitTransactionAsync();

            return salvo;
        }

        public async Task<List<HistoricoAlunoModel>> Historicos()
        {
            var obterTodosHistoricos = await _unitOfWork.historicoDoAluno.ObterTodos();
            var alunos = await _unitOfWork.Aluno.ObterTodos();
            var professores = await _unitOfWork.Professo.ObterTodos();

            foreach (var historico in obterTodosHistoricos)
            {
                historico.Aluno = alunos.FirstOrDefault(a => a.Id == historico.AlunoId);

                
                historico.Professor = professores.FirstOrDefault(p => p.Id == historico.ProfessorId);
            }

            var resultado =  HistoricoAlunoModel.ParaListaModel(obterTodosHistoricos);
            
           return resultado.ToList();
        }

        public async Task<List<HistoricoAlunoModel>> HistoricosDoAluno(Guid alunoId)
        {
            var obterTodosHistoricos = await _unitOfWork.historicoDoAluno.ListaHistoricoAluno(alunoId);
            var alunos = await _unitOfWork.Aluno.ObterTodos();
            var professores = await _unitOfWork.Professo.ObterTodos();

            foreach (var historico in obterTodosHistoricos)
            {
                historico.Aluno = alunos.FirstOrDefault(a => a.Id == historico.AlunoId);


                historico.Professor = professores.FirstOrDefault(p => p.Id == historico.ProfessorId);
            }

            var resultado = HistoricoAlunoModel.ParaListaModel(obterTodosHistoricos);

            return resultado.ToList();
        }

        public async Task<HistoricoAlunoModel> ObterPorId(Guid id)
        {
            var obtertHistorico = await _unitOfWork.historicoDoAluno.ObterPorId(id);

            if (obtertHistorico == null) return null;

            obtertHistorico.Aluno = await _unitOfWork.Aluno.ObterPorId(obtertHistorico.AlunoId);
            obtertHistorico.Professor = await _unitOfWork.Professo.ObterPorId(obtertHistorico.ProfessorId);

            var resultado = HistoricoAlunoModel.MapeamentoModel(obtertHistorico);

            return resultado;
        }

        public async Task<bool> RemoverHistorico(Guid id)
        {
            _unitOfWork.historicoDoAluno.Remover(id);

            var salvo = await _unitOfWork.CompleteAsync() > 0;

            await _unitOfWork.CommitTransactionAsync();

            return salvo;
        }
    }
}
