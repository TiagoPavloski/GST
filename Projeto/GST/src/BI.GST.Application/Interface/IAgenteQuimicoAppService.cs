using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IAgenteQuimicoAppService : IDisposable
    {
        IEnumerable<AgenteQuimicoViewModel> ObterTodos();

        AgenteQuimicoViewModel ObterPorId(int id);

        bool Adicionar(AgenteQuimicoViewModel agenteQuimicoViewModel);

        bool Atualizar(AgenteQuimicoViewModel agenteQuimicoViewModel);

        bool Excluir(int id);

        IEnumerable<AgenteQuimicoViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
