using Dominio.Entidades;
using Repositorio.IRepository.IRepositoryBase;
using Services.IServices;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class AlunoServices : IAlunoServices
    {
        private readonly IUnitOfWork? _unitOfWork;

        public AlunoServices(IUnitOfWork? unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AtulizarAluno(Guid id, AlunoAtualizarModel model)
        {
            var AtualizarAluno = await _unitOfWork.Aluno.ObterPorId(id);
            if (AtualizarAluno == null)
                return false;

            AtualizarAluno.AdiconarEAtualizarAluno(model.Nome, model.Email, model.DataNascimento, model.Telefone);

            _unitOfWork.Aluno.Atualizar(AtualizarAluno);

            var salvo = await _unitOfWork.CompleteAsync() > 0;

            await _unitOfWork.CommitTransactionAsync();

            return salvo;
        }

        public async Task<bool> CrearAluno(AlunoCriarModel model)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var aluno = new Aluno(model.Nome, model.Email, model.DataNascimento, model.Telefone);
                aluno.valorContratualAdicionar(model.ValorMensalidade, model.DiaVencimento);

                int proximoSequencial = await _unitOfWork.Aluno.ObterProximoSequencial();
                aluno.DefinirMatricula(proximoSequencial);

                aluno.AtribuirTurma(model.TurmaId);

                await _unitOfWork.Aluno.Adicionar(aluno);

                await _unitOfWork.CompleteAsync();

                var mensalidades = aluno.GerarCarneAnual();
                foreach (var m in mensalidades)
                {
                    await _unitOfWork.Mensalidade.Adicionar(m);
                }

                var salvou = await _unitOfWork.CompleteAsync() > 0;

                await _unitOfWork.CommitTransactionAsync();

                return salvou;
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                return false;
            }
        }

        public async Task<AlunoModel> ObterPorId(Guid id)
        {
            var obterAluno = await _unitOfWork.Aluno.ObterTodasInformaçoaDeUmAluno(id);

            if (obterAluno == null)
                return null;

            return new AlunoModel().Response(obterAluno);
        }

        public async Task<List<AlunoModel>> ObterTodos()
        {
            var todosAlunos = await _unitOfWork.Aluno.ObterTodosComInformacoes();

            return todosAlunos.Select(aluno => new AlunoModel().Response(aluno)).ToList();
        }

        public async Task RemoverAluno(Guid id)
        {
            var obterObjeto = _unitOfWork.Aluno.ObterPorId(id);

            if (obterObjeto == null) return;

            _unitOfWork.Aluno.RemoverObjeto(obterObjeto.Result);

            await _unitOfWork.CompleteAsync();
            await _unitOfWork.CommitTransactionAsync();
        }

        public async Task<bool> VinncularUmaTurma(Guid alunoid, Guid turmaid)
        {
            var alunoexiste = await _unitOfWork.Aluno.ObterPorId(alunoid);
            if (alunoexiste is null)
                return false;

            alunoexiste.AtribuirTurma(turmaid);

            _unitOfWork.Aluno.Atualizar(alunoexiste);

            var sucesso = await _unitOfWork.CompleteAsync() > 0;

            await _unitOfWork.CommitTransactionAsync();

            return sucesso;

        }
    }
}
