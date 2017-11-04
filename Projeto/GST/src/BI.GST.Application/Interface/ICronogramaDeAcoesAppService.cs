using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface ICronogramaDeAcoesAppService : IDisposable
    {
        CronogramaDeAcoesViewModel ObterPorId(int id);

        bool Adicionar(CronogramaDeAcoesViewModel cronogramaDeAcoesViewModel);

        bool Atualizar(CronogramaDeAcoesViewModel cronogramaDeAcoesViewModel);

        bool Excluir(int id);

        IEnumerable<CronogramaDeAcoesViewModel> ObterGrid(int page, string pesquisa, int ppraId);

        int ObterTotalRegistros(string pesquisa, int ppraId);

        IEnumerable<CronogramaDeAcoesViewModel> ObterPorPPRA(int ppraId);
    }
}
