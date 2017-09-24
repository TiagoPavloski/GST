using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IAgenteFisicoService : IDisposable
    {
        IEnumerable<AgenteFisico> ObterTodos();

        AgenteFisico ObterPorId(int id);

        IEnumerable<AgenteFisico> Find(Expression<Func<AgenteFisico, bool>> predicate);

        void Adicionar(AgenteFisico AgenteFisico);

        void Atualizar(AgenteFisico AgenteFisico);

        void Excluir(int id);

        IEnumerable<AgenteFisico> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
