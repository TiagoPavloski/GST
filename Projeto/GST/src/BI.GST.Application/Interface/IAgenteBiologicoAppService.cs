using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IAgenteBiologicoAppService : IDisposable
    {
        IEnumerable<AgenteBiologicoViewModel> ObterTodos();

        AgenteBiologicoViewModel ObterPorId(int id);

        bool Adicionar(AgenteBiologicoViewModel agenteBiologicoViewModel);

        bool Atualizar(AgenteBiologicoViewModel agenteBiologicoViewModel);

        bool Excluir(int id);

        IEnumerable<AgenteBiologicoViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
