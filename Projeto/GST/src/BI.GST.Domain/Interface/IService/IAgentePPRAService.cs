using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IAgentePPRAService : IDisposable
    {
        AgentePPRA ObterPorId(int id);

        IEnumerable<AgentePPRA> Find(Expression<Func<AgentePPRA, bool>> predicate);

        void Adicionar(AgentePPRA agentePPRA);

        void Atualizar(AgentePPRA agentePPRA);

        void Excluir(int id);

        IEnumerable<AgentePPRA> ObterGrid(int page, string pesquisa, int ppraId);

        int ObterTotalRegistros(string pesquisa, int ppraId);
    }
}
