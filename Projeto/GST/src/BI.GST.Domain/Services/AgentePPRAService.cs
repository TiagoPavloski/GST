using BI.GST.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.GST.Domain.Entities;
using System.Linq.Expressions;
using BI.GST.Domain.Interface.IRepository;

namespace BI.GST.Domain.Services
{
    public class AgentePPRAService : IAgentePPRAService
    {
        private readonly IAgentePPRARepository _agentePPRARepository;

        public AgentePPRAService(IAgentePPRARepository agentePPRARepository)
        {
            _agentePPRARepository = agentePPRARepository;
        }


        public void Adicionar(AgentePPRA agentePPRA)
        {
            _agentePPRARepository.Adicionar(agentePPRA);
        }

        public void Atualizar(AgentePPRA agentePPRA)
        {
            _agentePPRARepository.Atualizar(agentePPRA);
        }

        public void Dispose()
        {
            _agentePPRARepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _agentePPRARepository.Excluir(id);
        }

        public IEnumerable<AgentePPRA> Find(Expression<Func<AgentePPRA, bool>> predicate)
        {
            return _agentePPRARepository.Find(predicate);
        }

        public IEnumerable<AgentePPRA> ObterGrid(int page, string pesquisa)
        {
            return _agentePPRARepository.ObterGrid(page, pesquisa);
        }

        public AgentePPRA ObterPorId(int id)
        {
            return _agentePPRARepository.ObterPorId(id);
        }

        public IEnumerable<AgentePPRA> ObterTodos()
        {
            return _agentePPRARepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _agentePPRARepository.ObterTotalRegistros(pesquisa);
        }
    }
}
