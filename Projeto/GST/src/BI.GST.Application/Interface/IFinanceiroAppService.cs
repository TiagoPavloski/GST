using BI.GST.Application.ViewModels;
using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IFinanceiroAppService : IDisposable
    {
        bool Adicionar(FinanceiroViewModel financeiroViewModel);

        bool Atualizar(FinanceiroViewModel financeiroViewModel);

        bool Excluir(int id);

        IEnumerable<FinanceiroViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);

        List<FinanceiroViewModel> ObterContasPorOperacao(int operacao);

        List<FinanceiroViewModel> ObterContasPorDataVencimento(string dataInicial, string dataFinal);

        List<FinanceiroViewModel> ObterContasPorInstituicao(string instituicao);

        FinanceiroViewModel ObterContasPorId(int id);

    }
}
