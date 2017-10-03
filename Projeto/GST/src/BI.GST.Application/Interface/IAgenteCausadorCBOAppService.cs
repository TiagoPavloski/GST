using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IAgenteCausadorCBOAppService : IDisposable
    {
        IEnumerable<AgenteCausadorCBOViewModel> ObterTodos();

        AgenteCausadorCBOViewModel ObterPorId(int id);

        bool Adicionar(AgenteCausadorCBOViewModel agentCausadorCBOViewModel);

        bool Atualizar(AgenteCausadorCBOViewModel agentCausadorCBOViewModel);

        bool Excluir(int id);

        IEnumerable<AgenteCausadorCBOViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
