using Dominio;
using Dominio.Entidades;
using Repositorio.IRepository.IRepositoryBase;
using Services.IServices;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Services.Services
{
    public class ChamadaServices : IChamadaServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChamadaServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AlterarPresenca(Guid chamadaId, List<AlunoPresencaModel> alunos)
        {
           var itensDaChamada = await _unitOfWork.ChamadaItem.ObterPorChamadaId(chamadaId);

            if (itensDaChamada == null || !itensDaChamada.Any())
                return false;
            

            foreach (var alunoPresenca in alunos)
            {
                var item = itensDaChamada.FirstOrDefault(x => x.AlunoId == alunoPresenca.AlunoId);

                if(item != null)
                {
                    item.AlterarPresenca(alunoPresenca.Presente, alunoPresenca.Observacao);

                    _unitOfWork.ChamadaItem.Atualizar(item);
                }
            }

            var salvo =  await _unitOfWork.CompleteAsync() > 0;
            await _unitOfWork.CommitTransactionAsync();

            return salvo;
        }

        public async Task<ChamadaModel> ObterPorId(Guid id)
        {
            var chamada = await _unitOfWork.Chamada.ObterPorId(id);

            return new ChamadaModel().Response(chamada);
        }

        public async Task<IEnumerable<ChamadaModel>> ObterPorTurma(Guid turmaId)
        {
            var chamadas = await _unitOfWork.Chamada.ObterHistoricoPorTurma(turmaId);

            return chamadas.Select(c =>  new ChamadaModel().Response(c));
        }

        public async Task<bool> Registrar(AdicionarChamadaModel model)
        {
            var novaChama = new Chamada(model.TurmaId, model.DataAula);

            foreach (var aluno in model.Alunos)
            {
                novaChama.AdicionarLinhaPresenca(aluno.AlunoId,aluno.Presente,aluno.Observacao);
            }

            await _unitOfWork.Chamada.Adicionar(novaChama);

            var linhasAfetadas = await _unitOfWork.CompleteAsync();
            await _unitOfWork.CommitTransactionAsync();
            

            return linhasAfetadas > 0;
        }
    }
}
