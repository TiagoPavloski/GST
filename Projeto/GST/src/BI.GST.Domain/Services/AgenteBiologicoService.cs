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
    public class AgenteBiologicoService : IAgenteBiologicoService
    {
        private readonly IAgenteBiologicoRepository _agenteBiologicoRepository;

        public AgenteBiologicoService(IAgenteBiologicoRepository agenteBiologicoRepository)
        {
            _agenteBiologicoRepository = agenteBiologicoRepository;
        }

        public void Adicionar(AgenteBiologico agenteBiologico)
        {
            _agenteBiologicoRepository.Adicionar(agenteBiologico);
        }

        public void Atualizar(AgenteBiologico agenteBiologico)
        {
            _agenteBiologicoRepository.Atualizar(agenteBiologico);
        }

        public void Dispose()
        {
            _agenteBiologicoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _agenteBiologicoRepository.Excluir(id);
        }

        public IEnumerable<AgenteBiologico> Find(Expression<Func<AgenteBiologico, bool>> predicate)
        {
            return _agenteBiologicoRepository.Find(predicate); ;
        }

        public IEnumerable<AgenteBiologico> ObterGrid(int page, string pesquisa)
        {
            return _agenteBiologicoRepository.ObterGrid(page, pesquisa);
        }

        public AgenteBiologico ObterPorId(int id)
        {
            return _agenteBiologicoRepository.ObterPorId(id);
        }

        public IEnumerable<AgenteBiologico> ObterTodos()
        {
            return _agenteBiologicoRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _agenteBiologicoRepository.ObterTotalRegistros(pesquisa);
        }
    }
}
