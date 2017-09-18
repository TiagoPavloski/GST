using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IAgenteFisicoAppService : IDisposable
    {
        IEnumerable<AgenteFisicoViewModel> ObterTodos();

        AgenteFisicoViewModel ObterPorId(int id);

        bool Adicionar(AgenteFisicoViewModel agenteFisicoViewModel);

        bool Atualizar(AgenteFisicoViewModel agenteFisicoViewModel);

        bool Excluir(int id);

        IEnumerable<AgenteFisicoViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
