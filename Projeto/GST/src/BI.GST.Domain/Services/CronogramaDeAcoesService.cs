using BI.GST.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.GST.Domain.Entities;
using System.Linq.Expressions;
using BI.GST.Domain.Interface.IRepository;

namespace BI.GST.Domain.Services
{
    public class CronogramaDeAcoesService : ICronogramaDeAcoesService
    {
        private readonly ICronogramaDeAcoesRepository _cronogramaDeAcoesRepository;

        public CronogramaDeAcoesService(ICronogramaDeAcoesRepository cronogramaDeAcoesRepository)
        {
            _cronogramaDeAcoesRepository = cronogramaDeAcoesRepository;
        }

        public void Adicionar(CronogramaDeAcoes cronogramaDeAcoes)
        {
            _cronogramaDeAcoesRepository.Adicionar(cronogramaDeAcoes);
        }

        public void Atualizar(CronogramaDeAcoes cronogramaDeAcoes)
        {
            _cronogramaDeAcoesRepository.Atualizar(cronogramaDeAcoes);
        }

        public void Dispose()
        {
            _cronogramaDeAcoesRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _cronogramaDeAcoesRepository.Excluir(id);
        }

        public IEnumerable<CronogramaDeAcoes> Find(Expression<Func<CronogramaDeAcoes, bool>> predicate)
        {
            return _cronogramaDeAcoesRepository.Find(predicate);
        }

        public IEnumerable<CronogramaDeAcoes> ObterGrid(int page, string pesquisa, int ppraId)
        {
            return _cronogramaDeAcoesRepository.ObterGrid(page, pesquisa, ppraId);
        }

        public CronogramaDeAcoes ObterPorId(int id)
        {
            return _cronogramaDeAcoesRepository.ObterPorId(id);
        }

        public IEnumerable<CronogramaDeAcoes> ObterPorPPRA(int ppraId)
        {
            return _cronogramaDeAcoesRepository.ObterPorPPRA(ppraId);
        }

        public int ObterTotalRegistros(string pesquisa, int ppraId)
        {
            return _cronogramaDeAcoesRepository.ObterTotalRegistros(pesquisa, ppraId);
        }
    }
}
