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
        string Adicionar(FinanceiroViewModel financeiroViewModel, List<FinanceiroParcelaViewModel> parcelaViewModel);

        string Atualizar(FinanceiroViewModel financeiroViewModel, List<FinanceiroParcelaViewModel> parcelaViewModel);

        bool Excluir(int id);

        IEnumerable<FinanceiroViewModel> ObterGrid(int page, string pesquisa, int usuarioId);

        int ObterTotalRegistros(string pesquisa, int usuarioId);

        List<FinanceiroViewModel> ObterContasPorOperacao(int operacao);

        List<FinanceiroViewModel> ObterContasPorDataVencimento(string dataInicial, string dataFinal);

        List<FinanceiroViewModel> ObterContasPorInstituicao(string instituicao);

        FinanceiroViewModel ObterContasPorId(int id);

    }
}
