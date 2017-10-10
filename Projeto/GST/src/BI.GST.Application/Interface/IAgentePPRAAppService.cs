using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IAgentePPRAAppService : IDisposable
    {
        AgentePPRAViewModel ObterPorId(int id);

        bool Adicionar(AgentePPRAViewModel agentePPRAViewModel);

        bool Atualizar(AgentePPRAViewModel agentePPRAViewModel);

        bool Excluir(int id);

        IEnumerable<AgentePPRAViewModel> ObterGrid(int page, string pesquisa, int ppraId);

        int ObterTotalRegistros(string pesquisa,int ppraId);
    }
}
