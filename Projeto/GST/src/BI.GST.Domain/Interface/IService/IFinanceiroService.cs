using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace BI.GST.Domain.Interface.IService
{
    public interface IFinanceiroService : IDisposable
    {
        void Adicionar(Financeiro financeiro);

        void Atualizar(Financeiro financeiro);

        void Excluir(int id);

        IEnumerable<Financeiro> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);

        List<Financeiro> ObterContasPorOperacao(int operacao);

        List<Financeiro> ObterContasPorDataVencimento(string dataInicial, string dataFinal);

        List<Financeiro> ObterContasPorInstituicao(string instituicao);

        IEnumerable<Financeiro> Find(Expression<Func<Financeiro, bool>> predicate);

        Financeiro ObterPorId(int id);
    }
}
