using BI.GST.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using System.Linq.Expressions;

namespace BI.GST.Domain.Services
{
    public class FinanceiroService : IFinanceiroService
    {
        private readonly IFinanceiroRepository _financeiroRepository;

        public FinanceiroService(IFinanceiroRepository financeiroRepository)
        {
            _financeiroRepository = financeiroRepository;
        }

        public void Adicionar(Financeiro financeiro)
        {
            _financeiroRepository.Adicionar(financeiro);
        }

        public void Atualizar(Financeiro financeiro)
        {
            _financeiroRepository.Atualizar(financeiro);
        }

        public void Dispose()
        {
            _financeiroRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _financeiroRepository.Excluir(id);
        }

        public List<Financeiro> ObterContasPorDataVencimento(string dataInicial, string dataFinal)
        {
            return _financeiroRepository.ObterContasPorDataVencimento(dataInicial, dataFinal);
        }

        public List<Financeiro> ObterContasPorInstituicao(string instituicao)
        {
            return _financeiroRepository.ObterContasPorInstituicao(instituicao);
        }

        public List<Financeiro> ObterContasPorOperacao(int operacao)
        {
            return _financeiroRepository.ObterContasPorOperacao(operacao);
        }

        public IEnumerable<Financeiro> ObterGrid(int page, string pesquisa, int usuarioId)
        {
            return _financeiroRepository.ObterGrid(page, pesquisa, usuarioId);
        }

        public int ObterTotalRegistros(string pesquisa, int usuarioId)
        {
            return _financeiroRepository.ObterTotalRegistros(pesquisa, usuarioId);
        }

        public IEnumerable<Financeiro> Find(Expression<Func<Financeiro, bool>> predicate)
        {
            return _financeiroRepository.Find(predicate);
        }

        public Financeiro ObterPorId(int id)
        {
            return _financeiroRepository.ObterPorId(id);
        }
    }
}
