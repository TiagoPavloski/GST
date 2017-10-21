using BI.GST.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IRepository
{
    public interface IFinanceiroParcelaRepository : IBaseRepository<FinanceiroParcela>
    {
        IEnumerable<FinanceiroParcela> ObterGrid(int page, string pesquisa, int idFinanceiro);

        int ObterTotalRegistros(string pesquisa, int idFinanceiro);
    }
}
