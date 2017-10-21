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
    public class EPIService : IEPIService
    {
        private readonly IEPIRepository _epiRepository;

        public EPIService(IEPIRepository epiRepository)
        {
            _epiRepository = epiRepository;
        }

        public void Adicionar(EPI epi)
        {
            _epiRepository.Adicionar(epi);
        }

        public void Atualizar(EPI epi)
        {
            _epiRepository.Atualizar(epi);
        }

        public void Dispose()
        {
            _epiRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _epiRepository.Excluir(id);
        }

        public IEnumerable<EPI> Find(Expression<Func<EPI, bool>> predicate)
        {
            return _epiRepository.Find(predicate);
        }

        public IEnumerable<EPI> ObterGrid(int page, string pesquisa)
        {
            return _epiRepository.ObterGrid(page, pesquisa);
        }

        public EPI ObterPorId(int id)
        {
            return _epiRepository.ObterPorId(id);
        }

        public IEnumerable<EPI> ObterTodos()
        {
            return _epiRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _epiRepository.ObterTotalRegistros(pesquisa);
        }
    }
}
