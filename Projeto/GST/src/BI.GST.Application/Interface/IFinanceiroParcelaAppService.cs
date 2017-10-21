using BI.GST.Application.ViewModels;
using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IFinanceiroParcelaAppService : IDisposable
    {
        bool Adicionar(FinanceiroParcelaViewModel financeiroParcelaViewModel);

        bool Atualizar(FinanceiroParcelaViewModel financeiroParcelaViewModel);

        bool Excluir(int id);

        IEnumerable<FinanceiroParcelaViewModel> ObterGrid(int page, string pesquisa, int idFinanceiro);

        int ObterTotalRegistros(string pesquisa, int idFinanceiro);
    }
}
