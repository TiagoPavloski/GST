using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IFinanceiroParcelaService : IDisposable
    {
        void Adicionar(FinanceiroParcela financeiroParcela);

        void Atualizar(FinanceiroParcela financeiroParcela);

        void Excluir(int id);

        IEnumerable<FinanceiroParcela> ObterGrid(int page, string pesquisa, int idFinanceiro);

        int ObterTotalRegistros(string pesquisa, int idFinanceiro);

        IEnumerable<FinanceiroParcela> Find(Expression<Func<FinanceiroParcela, bool>> predicate);

        FinanceiroParcela ObterPorId(int id);
    }
}
