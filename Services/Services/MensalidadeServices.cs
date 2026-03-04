using Dominio.Entidades;
using Repositorio.IRepository.IRepositoryBase;
using Services.IServices;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class MensalidadeServices : IMensalidadeServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public MensalidadeServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ExcluirMensalidade(Guid id)
        {
            if (id == Guid.Empty)
                throw new Exception("Por favor digiti um Id que corresponde a uma mensalidade.");

            _unitOfWork.Mensalidade.Remover(id);

            var salvar = await _unitOfWork.CompleteAsync() > 0;

            await _unitOfWork.CommitTransactionAsync();

           return salvar;
        }

        public async Task<MensalidadeAtualizarAdicionarModel> GerarMensalidade(Guid alunoId, decimal valor, DateTime vencimento)
        {
            var mensalidadeAdicionar = new Mensalidade(alunoId, valor, vencimento);

            await _unitOfWork.Mensalidade.Adicionar(mensalidadeAdicionar);

            await _unitOfWork.CommitTransactionAsync();

            return new MensalidadeAtualizarAdicionarModel().Response(mensalidadeAdicionar);
        }

        public async Task<IEnumerable<MensalidadeModel>> ListarPorAluno(Guid alunoId)
        {
            var listaMensalidadeAluno =  await _unitOfWork.Mensalidade.ObterPeloIdAluno(alunoId);
            
            return listaMensalidadeAluno.Select(m => new MensalidadeModel().Response(m)).ToList();
        }

        public async Task<IEnumerable<MensalidadeModel>> ListarVencidas()
        {
            var listaMensalidadeVencidas = await _unitOfWork.Mensalidade.ListaVencidas();

            return listaMensalidadeVencidas.Select(m => new MensalidadeModel().Response(m)).ToList();
        }

        public async Task MudarStatusPagamento(Guid id, int novoStatus)
        {
            var obterMensalidade = await _unitOfWork.Mensalidade.ObterPorId(id);

            obterMensalidade.MudarStatus(novoStatus);

             _unitOfWork.Mensalidade.Atualizar(obterMensalidade);

            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitTransactionAsync();
        }

        public async Task<MensalidadeModel> ObterPorId(Guid id)
        {
            var obterMensalidade = await _unitOfWork.Mensalidade.ObterPorId(id);

            return new MensalidadeModel().Response(obterMensalidade);
        }

        public async Task<IEnumerable<MensalidadeModel>> ObterTodos()
        {
            var obterMenslaidades = await _unitOfWork.Mensalidade.ObterTodos();

            return obterMenslaidades.Select(m => new MensalidadeModel().Response(m)).ToList();
        }

        public async Task ProrrogarVencimento(Guid id, DateTime novaData)
        {
            var obterMensalida = await _unitOfWork.Mensalidade.ObterPorId(id);

            obterMensalida.AlteraDataVencimento(novaData);

            _unitOfWork.Mensalidade.Atualizar(obterMensalida);

            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitTransactionAsync();
        }
    }
}
