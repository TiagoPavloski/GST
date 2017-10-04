using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IAgenteCausadorCBOService : IDisposable
    {
        IEnumerable<AgenteCausadorCBO> ObterTodos();

        AgenteCausadorCBO ObterPorId(int id);

        IEnumerable<AgenteCausadorCBO> Find(Expression<Func<AgenteCausadorCBO, bool>> predicate);

        void Adicionar(AgenteCausadorCBO AgenteCausadorCBO);

        void Atualizar(AgenteCausadorCBO AgenteCausadorCBO);

        void Excluir(int id);

        IEnumerable<AgenteCausadorCBO> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
