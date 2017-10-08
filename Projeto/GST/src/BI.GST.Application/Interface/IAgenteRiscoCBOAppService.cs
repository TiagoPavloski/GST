using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IAgenteRiscoCBOAppService : IDisposable
    {
        IEnumerable<AgenteRiscoCBOViewModel> ObterTodos();

        AgenteRiscoCBOViewModel ObterPorId(int id);

        bool Adicionar(AgenteRiscoCBOViewModel agenteRiscoCBOViewModel);

        bool Atualizar(AgenteRiscoCBOViewModel agenteRiscoCBOViewModel);

        bool Excluir(int id);

        IEnumerable<AgenteRiscoCBOViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
