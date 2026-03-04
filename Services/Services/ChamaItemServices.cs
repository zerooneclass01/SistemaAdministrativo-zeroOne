using Repositorio.IRepository;
using Repositorio.IRepository.IRepositoryBase;
using Services.IServices;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class ChamaItemServices : IChamaItemServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChamaItemServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AtualizarPresencaIndividual(Guid itemId, bool presente, string observacao)
        {
            var item = await _unitOfWork.ChamadaItem.ObterPorId(itemId);
            if (item == null) throw new Exception("Registro de presença não encontrado.");

            item.AlterarPresenca(presente, observacao);

            _unitOfWork.ChamadaItem.Atualizar(item);

            var salvo = await _unitOfWork.CompleteAsync() > 0;
            await _unitOfWork.CommitTransactionAsync();

            return salvo;
        }

        public async Task<IEnumerable<ChamadaItemModel>> ObterPresencasPorAluno(Guid alunoId)
        {
           var resultado = await _unitOfWork.ChamadaItem.ObterPresencasPorAluno(alunoId);

            return resultado.Select(p => new ChamadaItemModel().Responser(p));
        }
    }
}
