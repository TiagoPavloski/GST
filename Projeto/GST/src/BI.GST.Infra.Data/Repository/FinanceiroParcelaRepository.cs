using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BI.GST.Infra.Data.Repository
{
    public class FinanceiroParcelaRepository : BaseRepository<FinanceiroParcela>, IFinanceiroParcelaRepository
    {
        public IEnumerable<FinanceiroParcela> ObterGrid(int page, string pesquisa, int idFinanceiro)
        {
            return DbSet.Where(x => (x.FinanceiroId == idFinanceiro) && (x.Delete == false))
                .OrderBy(u => u.DataVencimento)
                .Skip((page) * 10)
                .Take(10);
        }

        public int ObterTotalRegistros(string pesquisa, int idFinanceiro)
        {
            return DbSet.Count(x => (x.FinanceiroId == idFinanceiro) && (x.Delete == false));
        }
    }
}
