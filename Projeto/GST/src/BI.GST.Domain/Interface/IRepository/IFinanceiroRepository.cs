using BI.GST.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IRepository
{
    public interface IFinanceiroRepository : IBaseRepository<Financeiro>
    {
        IEnumerable<Financeiro> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);

        List<Financeiro> ObterContasPorOperacao(int operacao);

        List<Financeiro> ObterContasPorDataVencimento(string dataInicial, string dataFinal);

        List<Financeiro> ObterContasPorInstituicao(string instituicao);

    }
}
