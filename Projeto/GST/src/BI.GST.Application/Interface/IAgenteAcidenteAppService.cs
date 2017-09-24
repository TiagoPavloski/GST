using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IAgenteAcidenteAppService : IDisposable
    {
        IEnumerable<AgenteAcidenteViewModel> ObterTodos();

        AgenteAcidenteViewModel ObterPorId(int id);

        bool Adicionar(AgenteAcidenteViewModel agenteAcidenteViewModel);

        bool Atualizar(AgenteAcidenteViewModel agenteAcidenteViewModel);

        bool Excluir(int id);

        IEnumerable<AgenteAcidenteViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
