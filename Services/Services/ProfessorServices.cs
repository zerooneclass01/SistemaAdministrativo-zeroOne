using Dominio.Entidades;
using Microsoft.VisualBasic;
using Repositorio.IRepository.IRepositoryBase;
using Services.IServices;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class ProfessorServices : IProfessorServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfessorServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AtulizarProfessor(AdicionarAtualizaProfessorModel model)
        {
            var atualizarProfessor = await _unitOfWork.Professo.ObterPorId(model.Id);

            atualizarProfessor.InserirDados(model.Nome, model.Salario);

            _unitOfWork.Professo.Atualizar(atualizarProfessor);

            var salvo = await _unitOfWork.CompleteAsync() > 0;

            await _unitOfWork.CommitTransactionAsync();

            return salvo ;
        }

        public async Task<bool> CrearProfessor(AdicionarAtualizaProfessorModel model)
        {
            var crearProfessor = new Professor(model.Nome,model.Salario);
            
            await _unitOfWork.Professo.Adicionar(crearProfessor);

            var salvo = await _unitOfWork.CompleteAsync() > 0;

            await _unitOfWork.CommitTransactionAsync();

            return salvo;
        }

        public async Task<ProfessorModel> ObterPorId(Guid id)
        {
            var obterProfessor = await _unitOfWork.Professo.ObterPorId(id);

            if (obterProfessor == null)
                throw new Exception("Professo não encontrado na base de Dados!");

            return new ProfessorModel().Response(obterProfessor);
        }

        public async Task<List<ProfessorModel>> ObterTodos()
        {
            var obterProfessores = await _unitOfWork.Professo.ObterTodos();

            if (obterProfessores == null)
                return null;

            return obterProfessores.Select(p => new ProfessorModel().Response(p)).ToList();
        }

        public async Task RemoverProfessor(Guid id)
        {
            if (id == Guid.Empty)
                throw new Exception("Por gentileza digite um Id.");

            _unitOfWork.Professo.Remover(id);

            await _unitOfWork.CommitTransactionAsync();

        }
    }
}
