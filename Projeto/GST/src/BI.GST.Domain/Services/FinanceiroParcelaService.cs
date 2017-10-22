using BI.GST.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using System.Linq.Expressions;

namespace BI.GST.Domain.Services
{
    public class FinanceiroParcelaService : IFinanceiroParcelaService
    {

        private readonly IFinanceiroParcelaRepository _financeiroParcelaRepository;

        public FinanceiroParcelaService(IFinanceiroParcelaRepository financeiroParcelaRepository)
        {
            _financeiroParcelaRepository = financeiroParcelaRepository;
        }

        public void Adicionar(FinanceiroParcela financeiroParcela)
        {
            _financeiroParcelaRepository.Adicionar(financeiroParcela);
        }

        public void Atualizar(FinanceiroParcela financeiroParcela)
        {
            _financeiroParcelaRepository.Atualizar(financeiroParcela);
        }

        public void Dispose()
        {
            _financeiroParcelaRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _financeiroParcelaRepository.Excluir(id);
        }

        public IEnumerable<FinanceiroParcela> Find(Expression<Func<FinanceiroParcela, bool>> predicate)
        {
            return _financeiroParcelaRepository.Find(predicate);
        }

        public IEnumerable<FinanceiroParcela> ObterGrid(int page, string pesquisa, int idFinanceiro)
        {
            return _financeiroParcelaRepository.ObterGrid(page, pesquisa, idFinanceiro);
        }

        public FinanceiroParcela ObterPorId(int id)
        {
            return _financeiroParcelaRepository.ObterPorId(id);
        }

        public int ObterTotalRegistros(string pesquisa, int idFinanceiro)
        {
            return _financeiroParcelaRepository.ObterTotalRegistros(pesquisa, idFinanceiro);
        }
    }
}
