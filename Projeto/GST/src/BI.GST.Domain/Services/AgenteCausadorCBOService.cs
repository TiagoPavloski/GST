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
    public class AgenteCausadorCBOService : IAgenteCausadorCBOService
    {
        private readonly IAgenteCausadorCBORepository _agenteCausadorCBORepository;

        public AgenteCausadorCBOService(IAgenteCausadorCBORepository agenteCausadorCBORepository)
        {
            _agenteCausadorCBORepository = agenteCausadorCBORepository;
        }

        public void Adicionar(AgenteCausadorCBO agenteCausadorCBO)
        {
            _agenteCausadorCBORepository.Adicionar(agenteCausadorCBO);
        }

        public void Atualizar(AgenteCausadorCBO agenteCausadorCBO)
        {
            _agenteCausadorCBORepository.Atualizar(agenteCausadorCBO);
        }

        public void Dispose()
        {
            _agenteCausadorCBORepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _agenteCausadorCBORepository.Excluir(id);
        }

        public IEnumerable<AgenteCausadorCBO> Find(Expression<Func<AgenteCausadorCBO, bool>> predicate)
        {
            return _agenteCausadorCBORepository.Find(predicate);
        }

        public IEnumerable<AgenteCausadorCBO> ObterGrid(int page, string pesquisa)
        {
            return _agenteCausadorCBORepository.ObterGrid(page, pesquisa);
        }

        public AgenteCausadorCBO ObterPorId(int id)
        {
            return _agenteCausadorCBORepository.ObterPorId(id);
        }

        public IEnumerable<AgenteCausadorCBO> ObterTodos()
        {
            return _agenteCausadorCBORepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _agenteCausadorCBORepository.ObterTotalRegistros(pesquisa);
        }
    }
}
