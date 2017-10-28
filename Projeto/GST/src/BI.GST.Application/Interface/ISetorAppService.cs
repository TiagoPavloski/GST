using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface ISetorAppService : IDisposable
    {
        IEnumerable<SetorViewModel> ObterTodos();

        SetorViewModel ObterPorId(int id);

        bool Adicionar(SetorViewModel setorViewModel, int[] agenteAcidenteId, int[] agenteBiologicoId, int[] agenteErgonomicoId, int[] agenteFisicoId, int[] agenteQuimicoId);

        bool Atualizar(SetorViewModel setorViewModel, int[] agenteAcidenteId, int[] agenteBiologicoId, int[] agenteErgonomicoId, int[] agenteFisicoId, int[] agenteQuimicoId);

        bool Excluir(int id);

        IEnumerable<SetorViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
