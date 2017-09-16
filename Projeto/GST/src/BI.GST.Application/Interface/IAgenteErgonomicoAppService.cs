using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IAgenteErgonomicoAppService:IDisposable
    {
        IEnumerable<AgenteErgonomicoViewModel> ObterTodos();

        AgenteErgonomicoViewModel ObterPorId(int id);

        bool Adicionar(AgenteErgonomicoViewModel agenteErgonomicoViewModel);

        bool Atualizar(AgenteErgonomicoViewModel agenteErgonomicoViewModel);

        bool Excluir(int id);

        IEnumerable<AgenteErgonomicoViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
