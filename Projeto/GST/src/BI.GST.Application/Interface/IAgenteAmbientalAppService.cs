using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IAgenteAmbientalAppService : IDisposable
    {
        IEnumerable<AgenteAmbientalViewModel> ObterTodos();

        AgenteAmbientalViewModel ObterPorId(int id);

        bool Adicionar(AgenteAmbientalViewModel agenteAmbientalViewModel);

        bool Atualizar(AgenteAmbientalViewModel agenteAmbientalViewModel);

        bool Excluir(int id);

        IEnumerable<AgenteAmbientalViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
