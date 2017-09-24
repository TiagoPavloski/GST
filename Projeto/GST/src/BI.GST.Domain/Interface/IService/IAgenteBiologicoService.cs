using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
     public interface IAgenteBiologicoService :IDisposable
    {
        IEnumerable<AgenteBiologico> ObterTodos();

        AgenteBiologico ObterPorId(int id);

        IEnumerable<AgenteBiologico> Find(Expression<Func<AgenteBiologico, bool>> predicate);

        void Adicionar(AgenteBiologico AgenteBiologico);

        void Atualizar(AgenteBiologico AgenteBiologico);

        void Excluir(int id);

        IEnumerable<AgenteBiologico> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
