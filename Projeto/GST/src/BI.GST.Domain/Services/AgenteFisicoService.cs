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
    public class AgenteFisicoService : IAgenteFisicoService
    {
        private readonly IAgenteFisicoRepository _agenteFisicoRepository;

        public AgenteFisicoService(IAgenteFisicoRepository agenteFisicoRepository)
        {
            _agenteFisicoRepository = agenteFisicoRepository;
        }

        public void Adicionar(AgenteFisico agenteFisico)
        {
            _agenteFisicoRepository.Adicionar(agenteFisico);
        }

        public void Atualizar(AgenteFisico agenteFisico)
        {
            _agenteFisicoRepository.Atualizar(agenteFisico);
        }

        public void Dispose()
        {
            _agenteFisicoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _agenteFisicoRepository.Excluir(id);
        }

        public IEnumerable<AgenteFisico> Find(Expression<Func<AgenteFisico, bool>> predicate)
        {
            return _agenteFisicoRepository.Find(predicate);
        }

        public IEnumerable<AgenteFisico> ObterGrid(int page, string pesquisa)
        {
            return _agenteFisicoRepository.ObterGrid(page, pesquisa);
        }

        public AgenteFisico ObterPorId(int id)
        {
            return _agenteFisicoRepository.ObterPorId(id);
        }

        public IEnumerable<AgenteFisico> ObterTodos()
        {
            return _agenteFisicoRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _agenteFisicoRepository.ObterTotalRegistros(pesquisa);
        }
    }
}
